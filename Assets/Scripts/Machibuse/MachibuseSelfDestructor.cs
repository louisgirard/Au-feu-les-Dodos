using UnityEngine;

public class MachibuseSelfDestructor : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab = null;
    float dodoDamage = 1f;
    float rodeurHeal = 4f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Dodo"))
        {
            GameObject explosion = Instantiate(explosionPrefab, collision.transform.position, Quaternion.identity, collision.transform);
            Destroy(explosion, 0.5f);
            Destroy(gameObject);

            if(collision.CompareTag("Player"))
            {
                collision.GetComponent<PlayerEnjoyment>().TakeDamage("Machibuse");                
            }
            else
            {
                // Reduce dodo health
                collision.GetComponentInChildren<DodoHealth>().TakeDamage(dodoDamage);
            }
        }

        if (collision.CompareTag("Rodeur"))
        {
            Destroy(gameObject);
            collision.GetComponent<Extinguishment>().Heal(rodeurHeal);
        }
    }
}
