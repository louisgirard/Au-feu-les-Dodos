using UnityEngine;

public class Destruction : MonoBehaviour
{
    public float health;

    public void TakeDamage(float damage)
    {
        health = Mathf.Max(health - damage, 0);
        if (health == 0 && gameObject.CompareTag("Stump"))
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
