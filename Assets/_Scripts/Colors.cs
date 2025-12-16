using UnityEngine;

public class Colors : MonoBehaviour
{
    private SpriteRenderer _spriteRendererAlly;
    GameManager GameManager;
    public GameObject Manager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _spriteRendererAlly = GetComponent<SpriteRenderer>();
        GameManager = Manager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isAttacking == true)
        {
            _spriteRendererAlly.color = Color.yellow;
        }
    }
}
