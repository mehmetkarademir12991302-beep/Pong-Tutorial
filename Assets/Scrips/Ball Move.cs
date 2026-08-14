using UnityEngine;
using UnityEngine.InputSystem; 

public class BallMove : MonoBehaviour
{
    [Header("Top Ayari")]
    [SerializeField] private float speed = 10f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent <Rigidbody2D>();

        float Xdirection = 1f;
        float Ydirection = 1f;

        if(Random.Range(0,2) == 0) Xdirection = -1f;

        if(Random.Range(0,2) == 0) Ydirection = -1f;

        rb.linearVelocity = new Vector2(Xdirection,Ydirection).normalized*speed;
    }

    private void onCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x , -rb.linearVelocity.y);
        }

        else if(collision.gameObject.CompareTag("Player"))
        {
            rb.linearVelocity = new Vector2(-rb.linearVelocity.x , rb.linearVelocity.y);
        }
    }
}
