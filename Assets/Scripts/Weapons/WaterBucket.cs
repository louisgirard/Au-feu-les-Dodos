using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(PolygonCollider2D))]
public class WaterBucket : Weapon
{
    ParticleSystem ps;
    PolygonCollider2D polygonCollider2D;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
    }

    public override void Fire()
    {
        base.Fire();
        ps.Play();
        polygonCollider2D.enabled = true;
        StartCoroutine(DisableWater());
    }

    IEnumerator DisableWater()
    {
        yield return new WaitForSeconds(ps.main.duration);
        polygonCollider2D.enabled = false;
    }
}
