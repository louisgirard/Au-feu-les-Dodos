using UnityEngine;

public class GrenadeLauncher : Weapon
{
    [SerializeField] Projectile grenadePrefab = null;

    public override void Fire()
    {
        Projectile grenade = Instantiate(grenadePrefab, transform.position, Quaternion.identity);
        grenade.SetDestination(transform.position);
    }
}
