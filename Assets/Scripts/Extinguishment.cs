using UnityEngine;

public class Extinguishment : MonoBehaviour
{
    public float health;

    private float timer;

    private void Start()
    {
        timer = 0;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lance"))
        {
            if (timer >= health)
                Destroy(gameObject, 0.1f);
            else
                timer += Time.deltaTime;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lance"))
        {
            timer = 0;
        }
    }
}
