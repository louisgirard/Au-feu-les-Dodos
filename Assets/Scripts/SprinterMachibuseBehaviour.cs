using UnityEngine;

public class SprinterMachibuseBehaviour : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;   
    }

    void Update()
    {
        transform.Translate((player.position - transform.position).normalized * Time.deltaTime * speed);
    }
}
