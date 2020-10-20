using UnityEngine;
using UnityEngine.AI;

public class DodoAI : MonoBehaviour
{
    enum Mode { Passive, Active, Attacking };

    [SerializeField] float attackRange = 1f;
    [SerializeField] float power = 2f;

    Transform target;
    Transform player;
    NavMeshAgent agent;
    CharacterAnimation animator;
    Mode mode = Mode.Passive;
    bool isAttacking = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = player;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<CharacterAnimation>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        // Fix z axis to 0
        transform.position = new Vector2(transform.position.x, transform.position.y);

        // Target null = target dead
        if (target == null)
        {
            target = player;
            mode = Mode.Passive;
        }

        if (mode == Mode.Passive)
        {
            // Move to player
            target = player;
            MoveToTarget();
        }
        else if (mode == Mode.Active)
        {
            // If in range of attack then attack, else move to target
            float distanceToTarget = Vector2.Distance(transform.position, target.position);
            if (distanceToTarget <= attackRange)
            {
                Attack();
            }
            else
            {
                MoveToTarget();
            }
        }
    }

    private void MoveToTarget()
    {
        agent.isStopped = false;
        agent.SetDestination(target.position);

        if (!agent.velocity.normalized.Equals(Vector2.zero))
        {
            animator.SetOrientation(agent.velocity.normalized);
        }
        animator.Move(agent.velocity.normalized);
    }

    private void Attack()
    {
        agent.isStopped = true;
        // Face target
        Vector2 direction = (target.position - transform.position).normalized;
        animator.SetOrientation(direction);
        // Attack
        isAttacking = true;
        animator.Attack();
    }

    // Event in every attack animations
    private void AttackHitEvent()
    {
        if(target != null && !target.CompareTag("Player"))
        {
            // Damage to enemy
            Destroy(target.gameObject);
            print("damage");
        }
        isAttacking = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision == null) return;
        if (!collision.CompareTag("Enemy")) return;
        if (isAttacking) return;

        // Target in range, set new target
        if(mode == Mode.Passive)
        {
            mode = Mode.Active;
            target = collision.transform;
        }
        else if(mode == Mode.Active)
        {
            // Potentially change target
            float distanceToCurrentTarget = Vector2.Distance(transform.position, target.position);
            float distanceToPotentialTarget = Vector2.Distance(transform.position, collision.transform.position);
            if(distanceToPotentialTarget < distanceToCurrentTarget)
            {
                target = collision.transform;
            }
        }
    }
}