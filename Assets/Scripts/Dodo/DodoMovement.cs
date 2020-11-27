using UnityEngine;
using UnityEngine.AI;

public class DodoMovement : MonoBehaviour
{
    NavMeshAgent agent;
    CharacterAnimation animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<CharacterAnimation>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    public void MoveTo(Transform target)
    {
        agent.isStopped = false;
        agent.SetDestination(target.position);

        if (!agent.velocity.normalized.Equals(Vector2.zero))
        {
            animator.SetOrientation(agent.velocity.normalized);
        }
        animator.Move(agent.velocity.normalized);
    }

    public void Stop()
    {
        agent.isStopped = true;
        animator.Move(agent.velocity.normalized);
    }
}
