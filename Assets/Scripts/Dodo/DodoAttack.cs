using UnityEngine;

public class DodoAttack : MonoBehaviour
{
    [SerializeField] float attackRange = 1f;
    [SerializeField] float power = 1f;
    
    Transform currentTarget;
    CharacterAnimation animator;

    void Start()
    {
        animator = GetComponent<CharacterAnimation>();
    }

    public void Attack()
    {
        // Face target
        Vector2 direction = (currentTarget.position - transform.position).normalized;
        animator.SetOrientation(direction);
        // Attack
        animator.Attack();
    }

    // Event in every attack animations
    private void AttackHitEvent()
    {
        // During attack animation target could have died, changed, or left attack range
        if (currentTarget != null && !currentTarget.CompareTag("Player") && InAttackRange())
        {
            // Damage to enemy
            Extinguishment enemy = currentTarget.GetComponent<Extinguishment>();
            if (enemy != null)
            {
                enemy.TakeDamage(power);
            }
        }
    }

    public bool InAttackRange()
    {
        float distanceToTarget = Vector2.Distance(transform.position, currentTarget.position);
        return (distanceToTarget <= attackRange);
    }

    public void SetTarget(ref Transform target)
    {
        currentTarget = target;
    }
}
