using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachibuseGeneration : MonoBehaviour
{
    public GameObject machibuse;
    public float average_per_minute;

    private bool player_near;

    private void Update()
    {
        if (player_near)
        {
            if(Random.value < Time.deltaTime * average_per_minute / 60)
                Instantiate(machibuse, transform.position, Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            player_near = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            player_near = false;
    }
}
