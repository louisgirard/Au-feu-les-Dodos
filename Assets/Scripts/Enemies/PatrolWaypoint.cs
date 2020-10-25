using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolWaypoint : MonoBehaviour
{

    public PatrolWaypoint[] nextPossiblePoints;

    public PatrolWaypoint getNextPoint()
    {
        if (nextPossiblePoints.Length == 0) return null;
        return nextPossiblePoints[Random.Range(0, nextPossiblePoints.Length)];
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(transform.position, 0.1f);
        for (int i = 0; i < nextPossiblePoints.Length; i++)
        {
            Vector3 direction = nextPossiblePoints[i].transform.position - transform.position;
            Gizmos.DrawRay(transform.position, direction);
            Vector3 right = Quaternion.Euler(0, 0, 210) * direction.normalized * 0.3f;
            Vector3 left = Quaternion.Euler(0, 0, 150) * direction.normalized * 0.3f;
            Gizmos.DrawRay(transform.position + direction.normalized, right);
            Gizmos.DrawRay(transform.position + direction.normalized, left);
        }
    }
}
