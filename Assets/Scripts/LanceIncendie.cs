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
        var emission = ps.emission;
        if(CrossPlatformInputManager.GetButton("Fire1"))
        {
            emission.enabled = true;
        }
        else
        {
            emission.enabled = false;
        }
    }
}
