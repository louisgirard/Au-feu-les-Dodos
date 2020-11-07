﻿using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(BoxCollider2D))]
public class WaterGun : Weapon
{
    ParticleSystem ps;
    BoxCollider2D boxCollider2D;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public override void Fire()
    {
        var emission = ps.emission;
        emission.enabled = true;
        boxCollider2D.enabled = true;
    }

    public override void StopFire()
    {
        var emission = ps.emission;
        emission.enabled = false;
        boxCollider2D.enabled = false;
    }
}