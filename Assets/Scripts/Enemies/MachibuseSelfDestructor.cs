using UnityEngine;

public class MachibuseSelfDestructor : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.tag);
        if (collision.CompareTag("Player") || collision.CompareTag("Dodo"))
        {
            PlayerEnjoyment playerEnjoyment = (PlayerEnjoyment)FindObjectOfType(typeof(PlayerEnjoyment));
            GameObject explosion = Instantiate(explosionPrefab, collision.transform.position, Quaternion.identity, collision.transform);
            Destroy(explosion, 0.5f);
            Destroy(gameObject);

            if(collision.CompareTag("Player"))
            {
                playerEnjoyment.TakeDamage("Machibuse");                
            }
            else
            {
                // Reduce dodo health
                collision.GetComponentInChildren<DodoHealth>().TakeDamage(1);
            }
        }

        if (collision.CompareTag("Rodeur"))
        {
            Destroy(gameObject);
            collision.GetComponent<Extinguishment>().heal(0.6f);
        }
    }
}
