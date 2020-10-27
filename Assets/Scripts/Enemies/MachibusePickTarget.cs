using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachibusePickTarget : MonoBehaviour
{
    protected Transform target; // nearest between player, dodo or rodeur

    public virtual void Start()
    {
        Transform player = GameObject.FindWithTag("Player").transform;
        float min_distance = Vector3.Distance(player.position, transform.position);
        target = player;

        if (GameObject.FindWithTag("Dodo") != null)
        {
            Transform dodo = GameObject.FindWithTag("Dodo").transform;
            float distance = Vector3.Distance(dodo.position, transform.position);
            if (distance < min_distance)
            {
                min_distance = distance;
                target = dodo;
            }
        }

        GameObject[] rodeurs = GameObject.FindGameObjectsWithTag("Rodeur");
        foreach (GameObject r in rodeurs)
        {
            float distance = Vector3.Distance(r.transform.position, transform.position);
            if (distance < min_distance)
            {
                min_distance = distance;
                target = r.transform;
            }
        }
    }

}
