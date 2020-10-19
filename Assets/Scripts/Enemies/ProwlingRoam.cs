using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProwlingRoam : MonoBehaviour
{
    public float speed;

    private bool player_in_sight;
    private GameObject player;
    private Vector3 prowl_direction; // temporaire

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        prowl_direction = new Vector3(Random.value - 0.5f, Random.value - 0.5f, 0).normalized;
    }

    void Update()
    {
        if (player_in_sight)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.Translate(direction * Time.deltaTime * speed);
        }   
        else
        {
            prowl_direction = (prowl_direction + new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f), 0f)).normalized;
            transform.Translate(prowl_direction * Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player_in_sight = true;
        }        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player_in_sight = false;
        }
    }
}
