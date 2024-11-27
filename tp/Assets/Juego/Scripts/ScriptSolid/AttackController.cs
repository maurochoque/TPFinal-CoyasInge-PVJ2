using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRadius = 0.5f;
    [SerializeField] private int damage = 10;
    [SerializeField] private Animator animator;

    public void HandleAttack()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetTrigger("Attack1");
            PerformAttack();
        }
    }

    private void PerformAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius);

        foreach (var enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemigos"))
            {
                enemy.GetComponent<HealthController>()?.TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}

