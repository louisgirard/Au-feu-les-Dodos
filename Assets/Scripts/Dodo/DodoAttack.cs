using System.Collections;
using UnityEngine;


// Base class for Physical and Distance Attack
public class DodoAttack : MonoBehaviour
{
    [SerializeField] float attackRange = 0.8f;
    [SerializeField] float timeBetweenAttacks = 0f;
    
    protected Transform currentTarget;
    CharacterAnimation animator;

    bool canAttack = true;

    void Start()
    {
        animator = GetComponent<CharacterAnimation>();
    }

    public virtual void Attack()
    {
        // Attack
        if(canAttack)
        {
            StartCoroutine(AttackRoutine());
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

    IEnumerator AttackRoutine()
    {
        // Face target
        Vector2 direction = (currentTarget.position - transform.position).normalized;
        animator.SetOrientation(direction);
        animator.Attack();
        canAttack = false;
        yield return new WaitForSeconds(timeBetweenAttacks);
        canAttack = true;
    }
}
