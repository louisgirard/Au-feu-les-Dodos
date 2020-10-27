using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodeurAttack : MonoBehaviour
{
    public float speed;
    
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (GetComponentInChildren<PlayerDetection>().Get_player_in_sight())
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            transform.Translate(direction * Time.deltaTime * speed);
        }   
    }
}
