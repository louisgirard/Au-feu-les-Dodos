using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(ParticleSystem))]
public class LanceIncendie : MonoBehaviour
{
    ParticleSystem ps;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
  
        Vector3 mousePosition = CrossPlatformInputManager.mousePosition;

        var vel = ps.velocityOverLifetime;
        vel.enabled = true;
        vel.x = 0;
        vel.y = 0;
        vel.space = ParticleSystemSimulationSpace.Local;

        mousePosition.x -= Screen.width / 2;
        mousePosition.y -= Screen.height / 2;

        float xInput = CrossPlatformInputManager.GetAxisRaw("Horizontal aim");
        float yInput = -CrossPlatformInputManager.GetAxisRaw("Vertical aim");

        if (xInput == 0 && yInput == 0)
        {
            if(mousePosition.x <= 150 && mousePosition.y <= 150 && mousePosition.x >= -150 && mousePosition.y >= -150) // portée max de la lance
            {
                vel.x = mousePosition.x;
                vel.y = mousePosition.y;
            }

        }
        else
        {
            if (xInput <= 150 && yInput <= 150 && xInput >= -150 && yInput >= -150)
            {
                vel.x = xInput;
                vel.y = yInput;
            }

        }
    }
}
