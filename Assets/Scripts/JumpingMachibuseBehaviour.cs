using UnityEngine;

public class JumpingMachibuseBehaviour : MonoBehaviour
{
    public float jump_length;
    public float jump_duration;
    public AnimationCurve jump_curve;
    public float jump_pause;

    private Transform player; // final target
    private Vector3 start_position; // jump start
    private Vector3 target_position; // jump target
    private float jump_timer;
    private float pause_timer;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        jump_timer = jump_duration;
    }

    void Update()
    {
        jump_timer += Time.deltaTime;

        if (jump_timer >= jump_duration)
            Init_jump();

        else if (jump_timer >= 0)
            Jump();
    }

    void Init_jump()
    {
        start_position = transform.position;
        target_position = Vector3.MoveTowards(start_position, player.position, jump_length);
        jump_timer = - jump_pause;
    }
    
    void Jump()
    {
        transform.position = Vector3.Lerp(
            start_position,
            target_position,
            jump_curve.Evaluate(jump_timer / jump_duration));
    }
}
