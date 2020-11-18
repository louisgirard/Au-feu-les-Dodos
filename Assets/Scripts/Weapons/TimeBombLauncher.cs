using UnityEngine;

public class TimeBombLauncher : Weapon
{
    [SerializeField] WaterBombExplosion timeBombPrefab = null;

    public override void Fire()
    {
        base.Fire();
        WaterBombExplosion timeBomb = Instantiate(timeBombPrefab, transform.position, Quaternion.identity);
        timeBomb.StartTimer();
    }
}
