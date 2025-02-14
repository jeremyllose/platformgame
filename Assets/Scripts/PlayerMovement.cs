using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGrounded;

    [Header("Movement Settings")]
    public float speed = 5f;
    public float jumpForce = 14f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public LayerMask groundLayer;

    [Header("Character Type")]
    public string characterType; // "Ventus" or "Petra"

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D not found on the player object!");
        }
    }

    private void Update()
    {
        HandleMovement();
        HandleJump();
    }

    private void HandleMovement()
    {
        float moveX = 0;

        // Determine controls based on character type
        if (characterType == "Ventus")
        {
            if (Input.GetKey(KeyCode.D)) moveX = 1; // Right
            if (Input.GetKey(KeyCode.A)) moveX = -1; // Left
        }
        else if (characterType == "Petra")
        {
            if (Input.GetKey(KeyCode.RightArrow)) moveX = 1; // Right
            if (Input.GetKey(KeyCode.LeftArrow)) moveX = -1; // Left
        }
        else
        {
            Debug.LogError("Invalid character type. Please set 'characterType' to 'Ventus' or 'Petra'.");
        }

        // Apply horizontal movement
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);
    }

    private void HandleJump()
    {
        // Determine jump input based on character type
        bool jumpPressed = false;

        if (characterType == "Ventus" && Input.GetKeyDown(KeyCode.W))
        {
            jumpPressed = true;
        }
        else if (characterType == "Petra" && Input.GetKeyDown(KeyCode.UpArrow))
        {
            jumpPressed = true;
        }

        if (jumpPressed)
        {
            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                Debug.Log($"{characterType} jumped!");
            }
            else
            {
                Debug.LogWarning($"{characterType} tried to jump but is not grounded.");
            }
        }
    }

    private void FixedUpdate()
    {
        if (groundCheck != null)
        {
            Debug.Log($"Ground Check Position: {groundCheck.position}");
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);
            Debug.Log($"Ground Check at {groundCheck.position}, Result: {isGrounded}");
        }
        else
        {
            Debug.LogError("GroundCheck transform is not assigned!");
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a gizmo for the ground check position
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, 0.2f);
        }
    }
}
