using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(BoxCollider2D))]
public class LanceIncendie : Weapon
{
    AudioSource audioSource;
    ParticleSystem ps;
    BoxCollider2D boxCollider2D;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ps = GetComponent<ParticleSystem>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public override void Fire()
    {
        base.Fire();
        if(!audioSource.isPlaying)
            audioSource.Play();
        var emission = ps.emission;
        emission.enabled = true;
        boxCollider2D.enabled = true;
    }

    public override void StopFire()
    {
        base.StopFire();
        audioSource.Stop();
        var emission = ps.emission;
        emission.enabled = false;
        boxCollider2D.enabled = false;
    }
}
