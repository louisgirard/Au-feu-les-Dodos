using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EctoplasmaWalk : StateMachineBehaviour
{
    public float speed = 0.7f;
    private GameObject ectoplasma;
    private GameObject player;
    private float proximity_timer;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ectoplasma = GameObject.FindWithTag("Ectoplasma");
        player = GameObject.FindWithTag("Player");
        proximity_timer = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 move = (player.transform.position - ectoplasma.transform.position);
        ectoplasma.transform.Translate(move.normalized * speed * Time.deltaTime);

        if (move.magnitude < 1.5f) // trigger range for proximity explosion
            proximity_timer += Time.deltaTime;
        else
            proximity_timer = 0;

        if (proximity_timer > 1.5f)
        {
            animator.SetTrigger("Proximity");
            proximity_timer = 0;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
