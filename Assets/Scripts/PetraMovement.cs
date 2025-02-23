using UnityEngine;

public class PetraMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGrounded;
    private int jumpCount = 0;
    private int maxJumps = 1; 

    [Header("Movement Settings")]
    public float speed = 5f;
    public float jumpForce = 14f;
    public float stompForce = 20f;

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
        HandleStomp();
    }

    private void HandleMovement()
    {
        float moveX = 0;
        if (Input.GetKey(KeyCode.RightArrow)) moveX = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) moveX = -1;

        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCount < maxJumps)
        {
            jumpCount++;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            Debug.Log("Petra Jump!");
        }
    }

    private void HandleStomp()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, -stompForce);
            Debug.Log("Petra performed a Heavy Stomp!");
        }
    }

    private void FixedUpdate()
    {
        CheckGrounded();
    }

    private void CheckGrounded()
    {
        bool wasGrounded = isGrounded;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);

        if (isGrounded && !wasGrounded) 
        {
            jumpCount = 0;
            Debug.Log("✅ Petra landed! Jump reset.");
        }

        if (!isGrounded && wasGrounded) Debug.Log("❌ Petra is airborne!");
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
