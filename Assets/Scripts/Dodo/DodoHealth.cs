using UnityEngine;

public class DodoHealth : MonoBehaviour
{
    public float maxHealth = 4;
    public float health;
    [SerializeField] Sprite[] heads = null;
    DodoUI dodoUI;

    private void Start()
    {
        health = maxHealth;
        dodoUI = FindObjectOfType<DodoUI>();
        dodoUI.SetupHealthBars((int)health);
        dodoUI.SetupHead(heads);
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
        if (dodoUI.isBlinking && health > 1) return;

        health = Mathf.Max(health - damage, 0);
        if (health == 0)
        {
            print("dodo dead, game over");
        }
        dodoUI.UpdateHealth(health, true);
    }

    public void Heal(float points)
    {
        health = Mathf.Min(health + points, maxHealth);
        dodoUI.UpdateHealth(health);
    }

    public bool IsDying()
    {
        return (health <= 1);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Lance"))
        {
            Heal(Time.deltaTime);
        }
        else if (collision.CompareTag("Gun"))
        {
            Heal(Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GrenadeExplosion"))
        {
            Heal(2);
        }
        else if (collision.CompareTag("TimeBombExplosion"))
        {
            Heal(3);
        }
        else if (collision.CompareTag("MissileExplosion"))
        {
            Heal(3);
        }
        else if (collision.CompareTag("Bucket"))
        {
            Heal(1);
        }
    }
}
