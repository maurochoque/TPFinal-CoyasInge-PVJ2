using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform hero;

    private bool m_rolling = false;
    private int m_facingDirection = 1;
    private float m_delayToIdle = 0.0f;
    private const float rollDuration = 8.0f / 14.0f;

    private float rollTimer;

    public void UpdateAnimations(bool isGrounded, float inputX)
    {
        if (Mathf.Abs(inputX) > Mathf.Epsilon)
        {
            m_delayToIdle = 0.05f;
            animator.SetInteger("AnimState", 1);
        }
        else
        {
            m_delayToIdle -= Time.deltaTime;
            if (m_delayToIdle < 0)
            {
                animator.SetInteger("AnimState", 0); 
            }
        }

        if (inputX > 0)
        {
            m_facingDirection = 1;
        }
        else if (inputX < 0)
        {
            m_facingDirection = -1;
        }

        hero.localScale = new Vector3(m_facingDirection, 1, 1);

        animator.SetFloat("AirSpeedY", GetComponent<Rigidbody2D>().velocity.y);
        animator.SetBool("Grounded", isGrounded);

        if (m_rolling)
        {
            rollTimer += Time.deltaTime;
            if (rollTimer > rollDuration)
            {
                m_rolling = false;
            }
        }
    }

    public void TriggerJump()
    {
        animator.SetTrigger("Jump");
        animator.SetBool("Grounded", false);
    }

    public void TriggerAttack(int currentAttack)
    {
        animator.SetTrigger("Attack" + currentAttack);
    }

    public void TriggerRoll()
    {
        m_rolling = true;
        rollTimer = 0;
        animator.SetTrigger("Roll");
    }

    public void TriggerBlock(bool isBlocking)
    {
        animator.SetTrigger("Block");
        animator.SetBool("IdleBlock", isBlocking);
    }

    public void TriggerSlide(bool isWallSliding)
    {
        
        animator.SetBool("WallSlide", isWallSliding);
    }

    public void TriggerHurt()
    {
        animator.SetBool("Hurt", true);
    }

    public void TriggerDeath()
    {
        animator.SetBool("Death", true);
    }
}



