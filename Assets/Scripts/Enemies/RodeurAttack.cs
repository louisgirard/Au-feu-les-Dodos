using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodeurAttack : MonoBehaviour
{
    public float speed;

    private bool player_in_sight = false;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (player_in_sight)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            transform.Translate(direction * Time.deltaTime * speed);
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

    public bool Get_player_in_sight()
    {
        return player_in_sight;
    }
}
