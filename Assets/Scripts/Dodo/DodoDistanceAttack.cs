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

            projectile = Instantiate(projectilePrefab, transform.position, Orientation());

            Vector2 destination = currentTarget.position;
            projectile.SetDestination(destination);
        }
    }

    private Quaternion Orientation()
    {
        Vector2 direction = currentTarget.position - transform.position;

        float angle = Vector2.Angle(new Vector2(1, 0), direction);
        if (direction.y < 0)
        {
            angle = -angle;
        }

        return Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
