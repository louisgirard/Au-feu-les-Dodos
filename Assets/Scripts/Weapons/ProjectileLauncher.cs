using UnityEngine;

public class ProjectileLauncher : Weapon
{
    [SerializeField] Projectile grenadePrefab = null;
    [SerializeField] bool rotateProjectile = false;

    public override void Fire()
    {
        Projectile grenade;
        if (rotateProjectile)
        {
            grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        }
        else
        {
            grenade = Instantiate(grenadePrefab, transform.position, Quaternion.identity);
        }
        grenade.SetDestination(CursorPosition.ToScreen());
    }
}
