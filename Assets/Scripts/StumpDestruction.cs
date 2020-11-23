using UnityEngine;

public class StumpDestruction : MonoBehaviour
{
    public float health;

    public void TakeDamage(float damage)
    {
        health = Mathf.Max(health - damage, 0);
        if (health == 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Extinguishment[] fires = GetComponentsInChildren<Extinguishment>();
        foreach(Extinguishment fire in fires)
        {
            fire.TakeDamage(10);
        }
        Destroy(gameObject);
    }
}
