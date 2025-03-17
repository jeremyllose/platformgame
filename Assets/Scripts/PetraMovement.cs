using UnityEngine;
public class PetraMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 20f;
    private bool isGrounded;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movement
        float move = Input.GetAxis("HorizontalPetra");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        // Jumping
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Reset jump when touching the ground
                               // Prevent sticking to walls
            if (collision.contacts[0].normal.x != 0)
            {
                rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            }
        }
    }
}