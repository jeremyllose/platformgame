using UnityEngine;

public class VentusMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 20f;
    public float slowFallMultiplier = 0.1f;
    private int jumpCount;
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movement
        float move = Input.GetAxis("HorizontalVentus");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        // Jumping
        if (Input.GetKeyDown(KeyCode.W) && (isGrounded || jumpCount > 0))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpCount--;
        }

        // Apply slow fall if falling down
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (slowFallMultiplier - 1) * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 2; // Reset jumps when touching the ground
                           // Check if colliding from the side (wall)
            if (collision.contacts[0].normal.x != 0)
            {
                rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}