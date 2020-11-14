using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WideFrontalAttackState : StateMachineBehaviour
{
    public GameObject frontal_fires_zone_prefab;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform ectoplasma = GameObject.FindWithTag("Ectoplasma").transform;
        Vector2 target = GameObject.FindWithTag("Player").transform.position;
        Vector2 direction = ((Vector2)ectoplasma.position - target).normalized;
        Quaternion orientation = Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg, Vector3.forward);

        GameObject fires = Instantiate(frontal_fires_zone_prefab, ectoplasma.position, orientation);
        foreach (Transform fire in fires.transform)
        {
            fire.rotation = Quaternion.identity;
        }
        Destroy(fires, 5f);
    }
}
