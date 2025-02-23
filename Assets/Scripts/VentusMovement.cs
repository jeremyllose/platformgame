using UnityEngine;

public class VentusMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGrounded;
    private int jumpCount = 0;
    private int maxJumps = 2; 

    [Header("Movement Settings")]
    public float speed = 5f;
    public float jumpForce = 14f;
    public float slowFallMultiplier = 0.5f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public LayerMask groundLayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleMovement();
        HandleJump();
    }

    private void HandleMovement()
    {
        float moveX = 0;
        if (Input.GetKey(KeyCode.D)) moveX = 1;
        if (Input.GetKey(KeyCode.A)) moveX = -1;

        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.W) && jumpCount < maxJumps)
        {
            jumpCount++;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            Debug.Log($"Ventus Jump {jumpCount}!");
        }
    }

    private void FixedUpdate()
    {
        CheckGrounded(); // ✅ Ground detection now in FixedUpdate

        // Apply slow fall effect
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * slowFallMultiplier * Time.fixedDeltaTime;
        }
    }

    private void CheckGrounded()
    {
        bool wasGrounded = isGrounded;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);

        if (isGrounded && !wasGrounded) 
        {
            jumpCount = 0;
            Debug.Log("✅ Ventus landed! Jump reset.");
        }

        if (!isGrounded && wasGrounded) Debug.Log("❌ Ventus is airborne!");
    }

    private void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, 0.3f);
        }
    }
}
