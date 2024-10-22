﻿using UnityEngine;
//using UnityEngine.AI;

public class RodeurPatrol : MonoBehaviour
{
    public PatrolWaypoint waypoint;
    public float speed;
    
    void Update()
    {
        if (!GetComponentInChildren<PlayerDetection>().Get_player_in_sight())
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoint.transform.position, speed * Time.deltaTime);

            if (transform.position == waypoint.transform.position)
            {
                waypoint = waypoint.GetNextPoint();
            }
        }
    }
}