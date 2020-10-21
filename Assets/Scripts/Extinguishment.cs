using UnityEngine;

public class Extinguishment : MonoBehaviour
{
    public float health;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lance"))
        {
            TakeDamage(Time.deltaTime);
        }
    }

    public void TakeDamage(float damage)
    {
        health = Mathf.Max(health - damage, 0);
        if(health == 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject, 0.1f);
    }
}
