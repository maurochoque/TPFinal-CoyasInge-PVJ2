using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpForce = 12.0f;
    private Rigidbody2D rb;

    public float InputX { get; private set; }
    public bool IsGrounded { get; private set; }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void HandleMovement()
    {
        InputX = Input.GetAxis("Horizontal");

        Vector2 velocity = new Vector2(InputX * speed, rb.velocity.y);
        rb.velocity = velocity;

        if (Input.GetKeyDown(KeyCode.W) && IsGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            IsGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
    }
}

