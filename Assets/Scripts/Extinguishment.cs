using UnityEngine;

public class Extinguishment : MonoBehaviour
{
    public float health;
    public float rekindle_speed;

    private float max_health;

    private void Start()
    {
        max_health = health;
    }

    private void Update()
    {
        if (health < max_health)
            health += Time.deltaTime * rekindle_speed / 10;
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

    private void Death()
    {
        Destroy(gameObject);
    }
}
