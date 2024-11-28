using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRadius = 0.5f;
    [SerializeField] private int damage = 10;
    [SerializeField] private Animator animator;
    private int m_currentAttack = 0; // Numero de ataque actual en el combo
    private float m_timeSinceAttack = 0.0f;

    private void Update() {
        m_timeSinceAttack += Time.deltaTime;
    }

    public void HandleAttack()
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        if(Input.GetKeyDown(KeyCode.J) && m_timeSinceAttack > 0.25f)
        {
            rigid.velocity = Vector2.zero;
            //AudioManager.instance.Reproducir(5);
            m_currentAttack++;

            // Volver al uno despues del tercer ataque
            if (m_currentAttack > 3)
                m_currentAttack = 1;

            // Restablecer el combo de ataque si el tiempo desde el ultimo ataque es demasiado grande
            if (m_timeSinceAttack > 1.0f)
                m_currentAttack = 1;

            animator.SetTrigger("Attack" + m_currentAttack);// Llamar a una de las tres animaciones de ataque "Attack1", "Attack2", "Attack3"
            m_timeSinceAttack = 0.0f;// Restablecer temporizador
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
                enemy.GetComponent<Daño>()?.TomarDano(damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}

