using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingMachibuseBehaviour : MonoBehaviour
{
    public float speed;

    private Vector3 player_position;
    
    void Update()
    {
        Vector3 player_position = GameObject.FindWithTag("Player").transform.position;
        transform.Translate((player_position - transform.position).normalized * Time.deltaTime * speed);
    }
}
