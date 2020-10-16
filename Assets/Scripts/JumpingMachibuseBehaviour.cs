using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingMachibuseBehaviour : MonoBehaviour
{
    public float jump_length;
    public float jump_duration;
    public AnimationCurve jump_curve;
    public float jump_pause;

    private Vector3 player_position; // final target
    private Vector3 start_position; // jump start
    private Vector3 target_position; // jump target
    private float jump_timer;
    private float pause_timer;

    private void Start()
    {
        jump_timer = jump_duration;
    }

    void Update()
    {
        // Sprinteur : transform.Translate((player_position - transform.position).normalized * Time.deltaTime * speed);

        jump_timer += Time.deltaTime;

        if (jump_timer >= jump_duration)
            init_jump();

        else if (jump_timer >= 0)
            jump();
    }

    void init_jump()
    {
        start_position = transform.position;
        Vector3 player_position = GameObject.FindWithTag("Player").transform.position;
        target_position = Vector3.MoveTowards(start_position, player_position, jump_length);
        jump_timer = - jump_pause;
    }
    
    void jump()
    {
        transform.position = Vector3.Lerp(
            start_position,
            target_position,
            jump_curve.Evaluate(jump_timer / jump_duration));
    }
}
