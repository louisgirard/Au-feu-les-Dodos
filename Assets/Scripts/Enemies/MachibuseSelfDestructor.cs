using UnityEngine;

public class MachibuseSelfDestructor : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerEnjoyment playerEnjoyment = (PlayerEnjoyment)FindObjectOfType(typeof(PlayerEnjoyment));
        if (collision.CompareTag("Player") || collision.CompareTag("Dodo"))
        {
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
    }
}
