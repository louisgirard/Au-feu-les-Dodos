using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanceIncendie : MonoBehaviour
{

    void Start()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();

        var main = ps.main;
        main.startDelay = 0.0f;
        main.startLifetime = 2.0f;
        main.startSize = 0.1f;

    }


}
