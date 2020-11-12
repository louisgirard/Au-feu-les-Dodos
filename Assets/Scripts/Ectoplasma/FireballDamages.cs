using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballDamages : MonoBehaviour
{
    public float speed = 5;
    public GameObject explosion_prefab;

    private Vector2 direction;
    private PlayerEnjoyment playerEnjoyment;

    void Start()
    {
        playerEnjoyment = FindObjectOfType<PlayerEnjoyment>();
        Vector2 target = GameObject.FindWithTag("Player").transform.position;
        direction = (target - (Vector2)transform.position).normalized;
        transform.Rotate(Vector3.forward, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
    }
    
    void Update()
    {
        transform.Translate(Vector3.right *  speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerEnjoyment.TakeDamage("Ectoplasma fireball");
        }
        else if (collision.CompareTag("Dodo"))
        {
            collision.GetComponentInChildren<DodoHealth>().TakeDamage(1);
        }
        if (collision.CompareTag("Player") || collision.CompareTag("Dodo"))
        {
            GameObject explosion = Instantiate(explosion_prefab, collision.transform.position, Quaternion.identity, collision.transform);
            Destroy(explosion, 0.2f);
            Destroy(gameObject);
        }
    }
}
