using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    [SerializeField] private float speed = 15.0f;
    [SerializeField] private float jumpForce = 12.0f;
    [SerializeField] private Sensor_HeroKnight m_wallSensorR1;
    [SerializeField] private Sensor_HeroKnight m_wallSensorR2;
    [SerializeField] private Sensor_HeroKnight m_wallSensorL1;
    [SerializeField] private Sensor_HeroKnight m_wallSensorL2;
    [SerializeField] private float wallSlideSpeed = 5.0f;

    private Rigidbody2D rb;

    public float InputX { get; private set; }
    public bool IsGrounded { get; private set; }
    public bool IsWallSliding { get; private set; }

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

        bool m_isWallSliding = (m_wallSensorR1.State() && m_wallSensorR2.State()) || 
                               (m_wallSensorL1.State() && m_wallSensorL2.State());

        if (m_isWallSliding)
        {
            IsWallSliding = true;

            // educir la velocidad al deslizarse
            //rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed);

            FindObjectOfType<AnimationController>().TriggerSlide(true);
        }
        else
        {
            IsWallSliding = false;

            FindObjectOfType<AnimationController>().TriggerSlide(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = false;
        }
    }
}


