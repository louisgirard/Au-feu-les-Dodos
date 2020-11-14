using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : StateMachineBehaviour
{
    public float speed = 0.7f;
    public float patterns_pause = 5f;

    private GameObject ectoplasma;
    private GameObject player;
    private float pause_timer;
    private float proximity_timer;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ectoplasma = GameObject.FindWithTag("Ectoplasma");
        player = GameObject.FindWithTag("Player");
        pause_timer = 0;
        proximity_timer = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 move = (player.transform.position - ectoplasma.transform.position);
        ectoplasma.transform.Translate(move.normalized * speed * Time.deltaTime);

        if (move.magnitude < 1f) // trigger range for proximity explosion
            proximity_timer += Time.deltaTime;
        else
            proximity_timer = 0;

        pause_timer += Time.deltaTime;
        if (pause_timer > patterns_pause)
        {
            if (proximity_timer > 1f)
            {
                animator.SetTrigger("Proximity");
                proximity_timer = 0;
            }
            else
            {
                if (Random.value > 0.5f)
                    animator.SetTrigger("Shoot");
                else
                    animator.SetTrigger("Frontal attack");
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Shoot");
        animator.ResetTrigger("Frontal attack");
        animator.ResetTrigger("Proximity");
        animator.ResetTrigger("Meteorite");
    }

}
