using UnityEngine;

public class DodoPhysicalAttack : DodoAttack
{
    [SerializeField] float power = 1f;

    // Event in every attack animations
    private void AttackHitEvent()
    {
        // During attack animation target could have died, changed, or left attack range
        if (currentTarget != null && !currentTarget.CompareTag("Player") && InAttackRange())
        {
            // Damage to enemy
            Extinguishment enemy = currentTarget.GetComponent<Extinguishment>();
            if (enemy != null)
            {
                enemy.TakeDamage(power);
            }
        }
    }
}
