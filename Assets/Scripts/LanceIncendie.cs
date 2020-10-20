using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(BoxCollider2D))]
public class LanceIncendie : MonoBehaviour
{
    ParticleSystem ps;
    BoxCollider2D boxCollider2D;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        var emission = ps.emission;
        if(CrossPlatformInputManager.GetButton("Fire1"))
        {
            emission.enabled = true;
            boxCollider2D.enabled = true;

        }
        else
        {
            emission.enabled = false;
            boxCollider2D.enabled = false;
        }
    }
}
