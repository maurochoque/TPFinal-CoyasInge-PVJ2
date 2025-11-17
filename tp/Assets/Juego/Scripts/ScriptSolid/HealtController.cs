using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour, IHealth
{
    private float health = 100;

    [SerializeField] public Slider healthBar;

    private bool gameStarted = false; // para saber si el juego ha comenzado.

    public void StartGame()
    {
        gameStarted = true; //el juego comienza.
    }

    public void TakeDamage(int damage)
    {
        //  ejecutar despues de que el juego haya comenzado y si es el servidor
        if (!gameStarted) return;

        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        if (!gameStarted) return;

        health += amount;
        if (health > 100)
        {
            health = 100;
        }
    }

    private void OnHealthChange(float oldHealth, float newHealth)
    {
        healthBar.value = newHealth;
    }

    public void Die()
    {
        Debug.Log("Player died!");
    }
}

