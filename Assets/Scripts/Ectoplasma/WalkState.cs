using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : StateMachineBehaviour
{
    float speed;
    float patterns_pause;
    GameObject ectoplasma;
    GameObject player;
    float pause_timer;
    float proximity_timer;
    List<string> patterns;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ectoplasma = GameObject.FindWithTag("Ectoplasma");
        player = GameObject.FindWithTag("Player");
        pause_timer = 0;
        proximity_timer = 0;

        patterns = new List<string>();
        EctoplasmaPatternsSetUp paramaters = ectoplasma.GetComponent<EctoplasmaPatternsSetUp>();
        speed = paramaters.walking_speed;
        patterns_pause = paramaters.pause_between_patterns;
        if (paramaters.fireball_shoot_pattern)
            patterns.Add("Shoot");
        if (paramaters.WideFrontalAttackPattern)
            patterns.Add("Frontal attack");
        if (paramaters.MeteoriteRainPattern)
            patterns.Add("Meteorites");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 move = (player.transform.position - ectoplasma.transform.position);
        ectoplasma.transform.Translate(move.normalized * speed * Time.deltaTime);

        if (move.magnitude < 1.2f) // trigger range for proximity explosion
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
                int choice = (int) (Random.value * patterns.Count);
                animator.SetTrigger(patterns[choice]);
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Shoot");
        animator.ResetTrigger("Frontal attack");
        animator.ResetTrigger("Proximity");
        animator.ResetTrigger("Meteorites");
    }

}
