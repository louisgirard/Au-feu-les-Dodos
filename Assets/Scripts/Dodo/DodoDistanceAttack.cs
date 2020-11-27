using UnityEngine;

public class DodoDistanceAttack : DodoAttack
{
    [SerializeField] Projectile projectilePrefab = null;

    // Event in every attack animations
    private void AttackHitEvent()
    {
        // During attack animation target could have died, changed, or left attack range
        if (currentTarget != null && !currentTarget.CompareTag("Player") && InAttackRange())
        {
            // Spawn projectile
            Projectile projectile;

            projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            Vector2 destination = currentTarget.position;
            projectile.SetDestination(destination);
        }
    }
}
