using UnityEngine;

public class ProjectileLauncher : Weapon
{
    [SerializeField] Projectile projectilePrefab = null;
    [SerializeField] bool rotateProjectile = false;
    [SerializeField] float range = 10f;

    public override void Fire()
    {
        Projectile projectile;
        if (rotateProjectile)
        {
            projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
        else
        {
            projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        }

        Vector2 destination = CursorPosition.ToWorld();
        if (Vector2.Distance(transform.position, destination) > range)
        {
            destination = (Vector2)transform.position + CursorPosition.Position().normalized * range;
        }
        projectile.SetDestination(destination);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
