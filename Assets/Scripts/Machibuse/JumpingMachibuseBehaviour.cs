using UnityEngine;

public class JumpingMachibuseBehaviour : MachibusePickTarget
{
    public float jump_length;
    public float jump_duration;
    public AnimationCurve jump_curve;
    public float jump_pause;

    private Vector3 jump_start_position; 
    private Vector3 jump_end_position; 
    private float jump_timer;

    public override void Start()
    {
        base.Start();
        jump_timer = jump_duration;
    }

    void Update()
    {
        if (target == null)
        {
            base.Start();
            return;
        }

        jump_timer += Time.deltaTime;

        if (jump_timer >= jump_duration)
            Init_jump();

        else if (jump_timer >= 0)
            Jump();
    }

    void Init_jump()
    {
        jump_start_position = transform.position;
        Vector3 direction = (target.position - transform.position).normalized;
        if ((target.position - transform.position).magnitude > jump_length)
            direction = Quaternion.Euler(0, 0, Random.Range(-25f, 25f)) * direction;
        jump_end_position = transform.position + direction * jump_length;
        jump_timer = - jump_pause;
    }
    
    void Jump()
    {
        transform.position = Vector3.Lerp(
            jump_start_position,
            jump_end_position,
            jump_curve.Evaluate(jump_timer / jump_duration));
    }
}
