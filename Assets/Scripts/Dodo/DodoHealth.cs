using UnityEngine;

public class DodoHealth : MonoBehaviour
{
    [SerializeField] float maxHealth = 4;
    float health;
    DodoUI dodoUI;

    private void Start()
    {
        health = maxHealth;
        dodoUI = FindObjectOfType<DodoUI>();
        dodoUI.UpdateHealth(health);
    }

    private void Update()
    {
        // Slowly decrease health when last life
        if (health <= 1)
        {
            TakeDamage(Time.deltaTime / 4);
        }
    }

    public void TakeDamage(float damage)
    {
        health = Mathf.Max(health - damage, 0);
        if (health == 0)
        {
            print("dodo dead, game over");
        }
        dodoUI.UpdateHealth(health);
    }

    public void Heal(float points)
    {
        health = Mathf.Min(health + points, maxHealth);
        dodoUI.UpdateHealth(health);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Lance"))
        {
            Heal(Time.deltaTime);
        }
    }
}
