
using UnityEngine;

public class PlayGameManager : MonoBehaviour
{
    [SerializeField] private HealthController playerHealth;

   void Start()
{
    if (playerHealth == null)
    {
        playerHealth = FindObjectOfType<HealthController>();
    }

    if (playerHealth == null)
    {
        Debug.LogError("no se encontr un HealthController en la escena.");
        return;
    }

    DamageManager damageManager = new DamageManager();

    damageManager.ApplyDamage(playerHealth, 20);
}
}


