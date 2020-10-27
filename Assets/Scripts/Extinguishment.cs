using UnityEngine;

public class Extinguishment : MonoBehaviour
{
    public float health;
    public float rekindle_speed;

    private float max_health;
    private Vector3 start_scale;

    private void Start()
    {
        max_health = health;
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
        if (collision.gameObject.CompareTag("Lance"))
        {
            TakeDamage(Time.deltaTime);
        }
    }

    public void TakeDamage(float damage)
    {
        PlayerEnjoyment playerEnjoyment = (PlayerEnjoyment)FindObjectOfType(typeof(PlayerEnjoyment));
        health = Mathf.Max(health - damage, 0);
        if(health == 0)
        {
            playerEnjoyment.TakePleasure("Fire");
            Death();
        }
    }

    public void Heal(float value)
    {
        health = Mathf.Min(health + value, max_health);
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
