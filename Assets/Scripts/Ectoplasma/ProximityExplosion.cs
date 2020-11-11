using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityExplosion : StateMachineBehaviour
{
    public GameObject explosion_prefab;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 ectoplasma_pos = GameObject.FindWithTag("Ectoplasma").transform.position;
        GameObject explosion = Instantiate(explosion_prefab, ectoplasma_pos, Quaternion.identity);
        Destroy(explosion, 2f);
    }
}
