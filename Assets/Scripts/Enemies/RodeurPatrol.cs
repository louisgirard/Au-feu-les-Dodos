using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;

public class RodeurPatrol : MonoBehaviour
{
    public PatrolWaypoint waypoint;
    public float speed;

    void Update()
    {
        if (!GetComponent<RodeurAttack>().get_player_in_sight())
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoint.transform.position, speed * Time.deltaTime);

            if (transform.position == waypoint.transform.position)
            {
                waypoint = waypoint.getNextPoint();
            }
        }
    }
}