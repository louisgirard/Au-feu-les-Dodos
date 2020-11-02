using UnityEngine;

public class ProjectileLauncher : Weapon
{
    [SerializeField] Projectile projectilePrefab = null;
    [SerializeField] bool rotateProjectile = false;

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
        projectile.SetDestination(CursorPosition.ToScreen());
    }
}
