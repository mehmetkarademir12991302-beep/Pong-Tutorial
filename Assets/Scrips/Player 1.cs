using UnityEngine;
using UnityEngine.InputSystem;

public class Player1 : MonoBehaviour
{
    [Header("Hiz Ayari")]
    [SerializeField] private float speed = 7f;

    [Header("Sınır Ayarı")]
    [SerializeField] private float yLimit = 3.6f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Keyboard.current == null) return;

        float moveY = 0f;

        if (Keyboard.current.wKey.isPressed)
        {
            moveY = 1f;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            moveY = -1f;
        }

        rb.linearVelocity = new Vector2(0f, moveY * speed);

        float clampedY = Mathf.Clamp(transform.position.y, -yLimit, yLimit);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }
}