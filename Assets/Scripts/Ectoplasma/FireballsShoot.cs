using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballsShoot : StateMachineBehaviour
{
    public GameObject fireball_prefab;
    public float walking_speed = 0.7f;
    public float shooting_speed = 3;
    public int fireballs_count = 5;
    private GameObject ectoplasma;
    private GameObject player;
    private float shooting_timer;
    private int fireball_counter;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ectoplasma = GameObject.FindWithTag("Ectoplasma");
        player = GameObject.FindWithTag("Player");
        shooting_timer = 100;
        fireball_counter = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 move = (player.transform.position - ectoplasma.transform.position);
        ectoplasma.transform.Translate(move.normalized * walking_speed * Time.deltaTime);

        shooting_timer += Time.deltaTime;
        if (shooting_timer > 1/shooting_speed)
        {
            Instantiate(fireball_prefab, ectoplasma.transform.position, Quaternion.identity);
            shooting_timer = 0;
            fireball_counter++;
        }
        if (fireball_counter >= fireballs_count)
        {
            animator.SetTrigger("Shoot end");
        }
    }
}
