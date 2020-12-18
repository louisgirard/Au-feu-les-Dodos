using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballsShootState : StateMachineBehaviour
{
    public Fireball fireball_prefab;

    float walking_speed;
    float shooting_speed = 3;
    int fireballs_count = 5;

    GameObject ectoplasma;
    GameObject player;
    float shooting_timer;
    int fireball_counter;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ectoplasma = GameObject.FindWithTag("Ectoplasma");
        player = GameObject.FindWithTag("Player");
        shooting_timer = 100;
        fireball_counter = 0;
        
        EctoplasmaPatternsSetUp paramaters = ectoplasma.GetComponent<EctoplasmaPatternsSetUp>();
        walking_speed = paramaters.walking_speed;
        shooting_speed = paramaters.shooting_speed;
        fireballs_count = paramaters.fireballs_count;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 direction = (player.transform.position - ectoplasma.transform.position).normalized;
        ectoplasma.transform.Translate(direction * walking_speed * Time.deltaTime);

        shooting_timer += Time.deltaTime;
        if (shooting_timer > 1/shooting_speed)
        {
            Fireball fireball = Instantiate(fireball_prefab, ectoplasma.transform.position, Quaternion.identity);
            Destroy(fireball.gameObject, 10f);
            shooting_timer = 0;
            fireball_counter++;
        }
        if (fireball_counter >= fireballs_count)
        {
            animator.SetTrigger("Shoot end");
        }
    }
}
