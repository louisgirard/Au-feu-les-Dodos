using UnityEngine;

public class DodoHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 4;
    int health;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health = Mathf.Max(health - damage, 0);
        if (health == 0)
        {
            print("dodo dead, game over");
        }
        print(health);
    }

    public void Heal(int points)
    {
        health = Mathf.Min(health + points, maxHealth);
    }
}
