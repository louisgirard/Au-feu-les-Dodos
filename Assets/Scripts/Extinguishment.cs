using System.Net.NetworkInformation;
using UnityEngine;

public class Extinguishment : MonoBehaviour
{
    public float health;
    public float rekindle_speed;
    public bool is_scale_world_fixed = false;
    public Vector3 world_fixed_scale = new Vector3(0.17f, 0.17f, 0.17f);

    protected float max_health;
    private Vector3 start_scale;

    private void Start()
    {
        max_health = health;
        if (is_scale_world_fixed)
            start_scale = transform.parent.InverseTransformVector(world_fixed_scale);
        else
            start_scale = transform.localScale;
    }

    private void Update()
    {
        if (rekindle_speed > 0)
        {
            Heal(Time.deltaTime * rekindle_speed);
        }

        transform.localScale = start_scale * (health/(max_health*1.5f) + 0.5f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Lance"))
        {
            TakeDamage(Time.deltaTime);
        }
        else if (collision.CompareTag("Gun"))
        {
            TakeDamage(Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GrenadeExplosion"))
        {
            TakeDamage(0.5f);
        }
        else if (collision.CompareTag("TimeBombExplosion"))
        {
            TakeDamage(1);
        }
        else if (collision.CompareTag("MissileExplosion"))
        {
            TakeDamage(2);
        }
        else if (collision.CompareTag("Bucket"))
        {
            TakeDamage(1f);
        }
    }

    public void TakeDamage(float damage)
    {
        PlayerEnjoyment playerEnjoyment = (PlayerEnjoyment)FindObjectOfType(typeof(PlayerEnjoyment));
        health = Mathf.Max(health - damage, 0);
        if (health == 0 && gameObject.CompareTag("Fire"))
        {
            playerEnjoyment.TakePleasure("Fire");
            Death();
        }
        if (health == 0 && gameObject.CompareTag("Machibuse"))
        {
            playerEnjoyment.TakePleasure("Machibuse Death");
            Death();
        }
        if (health > 0 && gameObject.CompareTag("Rodeur"))
        {
            playerEnjoyment.TakePleasure("Rodeur Damage");
        }
        if (health == 0 && gameObject.CompareTag("Rodeur"))
        {
            playerEnjoyment.TakePleasure("Rodeur Death");
            Death();
        }
        if (health == 0 && gameObject.CompareTag("Ectoplasma"))
        {
            Death();
        }
    }

    public void Heal(float value)
    {
        health = Mathf.Min(health + value, max_health);
    }

    protected virtual void Death()
    {
        Destroy(gameObject);
    }
}
