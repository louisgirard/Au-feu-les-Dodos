using UnityEngine;

public class Bazookeau : Weapon
{
    [SerializeField] Projectile projectilePrefab = null;

    public override void Fire()
    {
        Projectile projectile;

        projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

        projectile.SetDestination(CursorPosition.ToWorld());
    }
}
