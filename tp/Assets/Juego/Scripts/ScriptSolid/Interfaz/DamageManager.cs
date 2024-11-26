using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public void ApplyDamage(IHealth healthEntity, int damage)
    {
        healthEntity.TakeDamage(damage);
    }
}

