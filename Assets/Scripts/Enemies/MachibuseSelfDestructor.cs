using UnityEngine;

public class MachibuseSelfDestructor : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameObject explosion = Instantiate(explosionPrefab, collision.transform.position, Quaternion.identity, collision.transform);
            Destroy(explosion, 0.5f);
            Destroy(gameObject);

            // Reduce Amusement Gauge
        }
    }
}
