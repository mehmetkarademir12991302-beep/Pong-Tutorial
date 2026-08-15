using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float hiz = 10f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;

        TopuFirlat();
    }

    void TopuFirlat()
    {
        float x = Random.Range(0, 2) == 0 ? -1f : 1f;
        float y = Random.Range(0, 2) == 0 ? -1f : 1f;

        rb.linearVelocity = new Vector2(x, y).normalized * hiz;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.linearVelocity = new Vector2(-rb.linearVelocity.x, rb.linearVelocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Goal"))
        {
            transform.position = Vector2.zero;
            rb.linearVelocity = Vector2.zero;
            TopuFirlat();
        }
    }
}