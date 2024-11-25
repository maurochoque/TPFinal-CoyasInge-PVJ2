using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void UpdateAnimations(bool isGrounded, float inputX)
    {
        // Configura el estado de la animación según el movimiento horizontal
        if (Mathf.Abs(inputX) > Mathf.Epsilon)
        {
            animator.SetInteger("AnimState", 1); // Corriendo
        }
        else
        {
            animator.SetInteger("AnimState", 0); // Idle
        }

        // Configura la velocidad en el aire
        animator.SetFloat("AirSpeedY", GetComponent<Rigidbody2D>().velocity.y);
        animator.SetBool("Grounded", isGrounded);
    }
}

