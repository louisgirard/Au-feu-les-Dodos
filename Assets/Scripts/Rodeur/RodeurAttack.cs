using System.Collections;
using UnityEngine;

public class RodeurAttack : MonoBehaviour
{
    public float walk_speed = 1f;
    public float underground_dash_time = 1.1f;
    public float pause_between_dash = 4.5f;
    public float dash_trigger_range = 5;
    public float hit_trigger_range = 0.8f;
    public float hit_reloading_time = 3f;
    public GameObject rift;
    public GameObject claw_mark_prefab;

    private bool ready_to_dash;
    private bool ready_to_hit;
    private bool stop;
    private Transform player;
    private Animator animator;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        stop = false;
        ready_to_dash = true;
        ready_to_hit = true;
        rift.SetActive(false);
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (GetComponentInChildren<PlayerDetection>().Get_player_in_sight())
        {
            if (ready_to_dash && Vector2.Distance(player.position, transform.position) > 1)
            {
                StartCoroutine(Underground_dash());
            }
            else if (!stop)
            {
                Vector2 direction = (player.position - transform.position).normalized;
                transform.Translate(direction * Time.deltaTime * walk_speed);
                if (ready_to_hit && Vector2.Distance(player.position, transform.position) < hit_trigger_range)
                {
                    StartCoroutine(Hit());
                }
            }
        }
    }

    IEnumerator Hit()
    {
        ready_to_hit = false;
        stop = true;
        if (player.position[0] - transform.position[0] > 0)
        {
            animator.Play("Right Claw Hit");
            transform.Find("Right Claw Aim").gameObject.GetComponent<ClawHitAim>().HitMove(player.position);
        }
        else
        {
            animator.Play("Left Claw Hit");
            transform.Find("Left Claw Aim").gameObject.GetComponent<ClawHitAim>().HitMove(player.position);
        }

        yield return new WaitForSeconds(0.7f);
        stop = false;

        yield return new WaitForSeconds(hit_reloading_time);
        ready_to_hit = true;
    }

    IEnumerator Underground_dash()
    {
        ready_to_dash = false;
        stop = true;

        yield return new WaitForSeconds(0.2f);
        foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
            sr.enabled = false;
        GetComponent<Extinguishment>().enabled = false;
        transform.position = player.transform.position;

        yield return new WaitForSeconds(underground_dash_time - 0.8f);
        rift.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
            sr.enabled = true;
        GetComponent<Extinguishment>().enabled = true;
        rift.SetActive(false);

        yield return new WaitForSeconds(0.2f);
        stop = false;

        yield return new WaitForSeconds(pause_between_dash);
        ready_to_dash = true;
    }

    public void RightHitEvent()
    {
        transform.Find("Right Claw Aim").GetComponentInChildren<ClawHit>().AttackHitEvent();
        GameObject claw_mark = Instantiate(claw_mark_prefab, transform.Find("Right Claw Aim").position, Quaternion.identity);
        Destroy(claw_mark, 1.0f);
    }
    public void LeftHitEvent()
    {
        transform.Find("Left Claw Aim").gameObject.GetComponentInChildren<ClawHit>().AttackHitEvent();
        GameObject claw_mark = Instantiate(claw_mark_prefab, transform.Find("Left Claw Aim").position, Quaternion.identity);
        Destroy(claw_mark, 1.0f);
    }
}
