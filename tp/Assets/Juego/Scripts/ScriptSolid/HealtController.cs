using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class HealthController : NetworkBehaviour
{
    [SyncVar(hook = nameof(OnHealthChange))]
    private float health = 100;

    [SerializeField] private Slider healthBar;

    public void TakeDamage(int damage)
    {
        if (!isServer) return;

        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void OnHealthChange(float oldHealth, float newHealth)
    {
        healthBar.value = newHealth;
    }

    private void Die()
    {
        Debug.Log("Player died!");
        // Handle death logic
    }
}

