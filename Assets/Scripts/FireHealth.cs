using UnityEngine;

public class FireHealth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Lance"))
        {
            Destroy(gameObject);
        }
        
    }
}
