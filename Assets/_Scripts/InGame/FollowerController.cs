using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FollowerController : MonoBehaviour
{
    // Target position
    public Transform target;

    [Header("Movement")] // Movement settings
    [SerializeField] private float moveSpeed = 15f; // Speed setting
    [SerializeField] float acceletarion = 35f; // Speed setting
    [SerializeField] float deceleration = 45f; // Speed setting
    public float followDistance = 5f;

    [Header("Obstacle Avoidance")] // Avoidance settings
    public float rayDistance = 2f;
    public LayerMask obstacleLayer;
    public float avoidStrength = 3f;

    private Rigidbody2D rb;
    private Camera mainCam;

    void Start()
    {
        // Finding follower's rb and camera
        rb = GetComponent<Rigidbody2D>();
        mainCam = Camera.main;

    }
    void TeleportNearPlayer()
    {
        if (target == null) return; // Does not run if there is no movement

        float radius = 1f;

        #region Avoidance Logic
        // Try fixed directions first (cleaner than random)
        Vector2[] directions = new Vector2[]
        {
        Vector2.right,
        Vector2.left,
        Vector2.up,
        Vector2.down,
        (Vector2.right + Vector2.up).normalized,
        (Vector2.left + Vector2.up).normalized,
        (Vector2.right + Vector2.down).normalized,
        (Vector2.left + Vector2.down).normalized
        };

        foreach (Vector2 dir in directions)
        {
            Vector2 candidate = (Vector2)target.position + dir * radius;

            if (!Physics2D.OverlapCircle(candidate, 0.4f, obstacleLayer))
            {
                transform.position = candidate;
                rb.linearVelocity = Vector2.zero;
                return;
            }
        }

        // If all fail, shrink radius and try closer
        float smallerRadius = radius * 0.5f;

        foreach (Vector2 dir in directions)
        {
            Vector2 candidate = (Vector2)target.position + dir * smallerRadius;

            if (!Physics2D.OverlapCircle(candidate, 0.4f, obstacleLayer))
            {
                transform.position = candidate;
                rb.linearVelocity = Vector2.zero;
                return;
            }
        }

        // 3️⃣ Absolute fallback: force to player position
        transform.position = target.position;
        rb.linearVelocity = Vector2.zero;
        #endregion
    }


    void FixedUpdate()
    {
        if (target == null) return;

        Vector2 toTarget = target.position - transform.position; // Vector to the Player's trail
        float distance = toTarget.magnitude;

        Vector2 followForce = Vector2.zero;

        // If close enough, stop
        if (distance > followDistance)
        {
            followForce = toTarget.normalized;
        }


        Vector2 avoidForce = Vector2.zero;

        // 🔎 Raycast to detect obstacle
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            toTarget.normalized,
            rayDistance,
            obstacleLayer
        );

        if (hit.collider != null)
        {
            // Obstacle detected: steer sideways
            Vector2 perpendicular = Vector2.Perpendicular(toTarget.normalized);
            avoidForce = perpendicular * avoidStrength;
        }

        Vector2 finalDirection = followForce + avoidForce;

        if ( finalDirection != Vector2.zero)
            finalDirection.Normalize();

        Vector2 targetVelocity = finalDirection * moveSpeed;

        if (finalDirection.magnitude > 0.1f)
        {
            rb.linearVelocity = Vector2.MoveTowards(
                rb.linearVelocity,
                targetVelocity,
                acceletarion * Time.fixedDeltaTime
                );
        }
        else
        {
            rb.linearVelocity = Vector2.MoveTowards(
                rb.linearVelocity,
                Vector2.zero,
                deceleration * Time.fixedDeltaTime
                );
        }
    }

    void LateUpdate()
    {
        // Teleport near player if off the screen
        if (!IsVisible())
        {
            TeleportNearPlayer();
        }

        bool IsVisible()
        {
            Vector3 viewportPos = mainCam.WorldToViewportPoint(transform.position);

            return viewportPos.x > 0 &&
                viewportPos.x < 1 &&
                viewportPos.y > 0 &&
                viewportPos.y < 1 &&
                viewportPos.z > 0;
        }
    }
}
