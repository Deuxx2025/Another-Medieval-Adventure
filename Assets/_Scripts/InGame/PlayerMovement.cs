using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement: MonoBehaviour
{
    [SerializeField] private float speed = 15f; // Speed setting
    [SerializeField] float acceletarion = 35f; // Speed setting
    [SerializeField] float deceleration = 45f; // Speed setting


    private Vector2 moveInput; // Arrows or WASD movement
    private Rigidbody2D rb; // rb

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>(); // Get rb
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>().normalized; // Read input direction
    }

    private void FixedUpdate()
    {
        Vector2 targetVelocity = moveInput * speed;

        if(moveInput.magnitude > 0.1f)
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
}
