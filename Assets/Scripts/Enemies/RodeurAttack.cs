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

    private bool ready_to_dash;
    private bool ready_to_hit;
    private bool stop;
    private Transform player;
    private PlayerEnjoyment playerEnjoyment;
    private Animator animator;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        stop = false;
        ready_to_dash = true;
        ready_to_hit = true;
        rift.SetActive(false);
        playerEnjoyment = (PlayerEnjoyment)FindObjectOfType(typeof(PlayerEnjoyment));
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
        animator.Play("Left Claw Hit");

        yield return new WaitForSeconds(1.1f);
        stop = false;

        yield return new WaitForSeconds(hit_reloading_time);
        ready_to_hit = true;
    }

    public void AttackHitEvent()
    {
        GetComponentInChildren<ClawHit>().AttackHitEvent();
    }

    IEnumerator Underground_dash()
    {
        ready_to_dash = false;
        stop = true;

        yield return new WaitForSeconds(0.3f);
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

        yield return new WaitForSeconds(0.3f);
        stop = false;

        yield return new WaitForSeconds(pause_between_dash);
        ready_to_dash = true;
    }
}
