using UnityEngine;

// Base class for Physical and Distance Attack
public class DodoAttack : MonoBehaviour
{
    [SerializeField] float attackRange = 0.8f;
    
    protected Transform currentTarget;
    CharacterAnimation animator;

    void Start()
    {
        animator = GetComponent<CharacterAnimation>();
    }

    public virtual void Attack()
    {
        // Face target
        Vector2 direction = (currentTarget.position - transform.position).normalized;
        animator.SetOrientation(direction);
        // Attack
        animator.Attack();
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
