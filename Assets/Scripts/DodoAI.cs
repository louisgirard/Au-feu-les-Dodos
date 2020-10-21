using UnityEngine;
using UnityEngine.AI;

public class DodoAI : MonoBehaviour
{
    enum Mode { Passive, Active };

    [SerializeField] float attackRange = 1f;
    [SerializeField] float power = 1f;
    [SerializeField] bool canAttackRodeur = false;

    Transform target;
    Transform player;
    NavMeshAgent agent;
    CharacterAnimation animator;
    Mode mode = Mode.Passive;

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
            if (InAttackRange())
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
        animator.Attack();
    }

    // Event in every attack animations
    private void AttackHitEvent()
    {
        // During attack animation target could have died, changed, or left attack range
        if(target != null && !target.CompareTag("Player") && InAttackRange())
        {
            // Damage to enemy
            Extinguishment enemy = target.GetComponent<Extinguishment>();
            if(enemy != null)
            {
                enemy.TakeDamage(power);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(canAttackRodeur)
        {
            if (!collision.CompareTag("Machibuse") && !collision.CompareTag("Rodeur")) return;
        }
        else
        {
            if (!collision.CompareTag("Machibuse")) return;
        }

        // Target in range, set new target
        if(mode == Mode.Passive)
        {
            mode = Mode.Active;
            target = collision.transform;
        }
        else if(mode == Mode.Active)
        {
            // Target null = dead then change target
            if (target == null)
            {
                target = collision.transform;
            }
            else
            {
                // Target not dead, check if new target is closer
                float distanceToCurrentTarget = Vector2.Distance(transform.position, target.position);
                float distanceToPotentialTarget = Vector2.Distance(transform.position, collision.transform.position);
                if (distanceToPotentialTarget < distanceToCurrentTarget)
                {
                    target = collision.transform;
                }
            }
        }
    }

    private bool InAttackRange()
    {
        float distanceToTarget = Vector2.Distance(transform.position, target.position);
        return (distanceToTarget <= attackRange);
    }
}