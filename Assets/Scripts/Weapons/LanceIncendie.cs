using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(BoxCollider2D))]
public class LanceIncendie : Weapon
{
    AudioSource audioSource;
    ParticleSystem ps;
    BoxCollider2D boxCollider2D;

    [SerializeField] Transform baseLance = null;
    [SerializeField] Transform player = null;
    float offset = 0.1f;

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

    protected override void Orientation()
    {
        Vector2 cursorPosition = CursorPosition.Position();

        float angle = Vector2.Angle(new Vector2(1, 0), cursorPosition);
        if (cursorPosition.y < 0)
        {
            angle = -angle;
        }

        baseLance.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Offset position
        if (player.GetComponent<CharacterAnimation>().Animation().Equals("Walk Left"))
        {
            baseLance.position = new Vector2(player.position.x - offset, baseLance.position.y);
        }
        else if (player.GetComponent<CharacterAnimation>().Animation().Equals("Walk Right"))
        {
            baseLance.position = new Vector2(player.position.x + offset, baseLance.position.y);
        }
        else
        {
            baseLance.position = new Vector2(player.position.x, baseLance.position.y);
        }
    }
}
