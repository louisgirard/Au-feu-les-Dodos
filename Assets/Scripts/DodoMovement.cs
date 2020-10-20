//using UnityEngine;
//using Pathfinding;

//public class DodoMovement : MonoBehaviour
//{
//    [SerializeField] float speed = 2f;
//    [SerializeField] float nextWaypointDistance = .5f;
//    [SerializeField] float stoppingDistance = 1f;
//    Transform player;
//    CharacterAnimation animator;
//    new Rigidbody2D rigidbody;

//    Path path;
//    int currentWaypoint = 0;
//    Seeker seeker;

//    void Start()
//    {
//        player = GameObject.FindGameObjectWithTag("Player").transform;
//        animator = GetComponent<CharacterAnimation>();
//        rigidbody = GetComponent<Rigidbody2D>();
//        seeker = GetComponent<Seeker>();

//        InvokeRepeating("UpdatePath", 0f, 0.1f);
//    }

//    private void FixedUpdate()
//    {
//        if (path == null) return;

//        float distanceToTarget = Vector2.Distance(transform.position, player.position);
//        if (distanceToTarget <= stoppingDistance)
//        {
//            animator.Move(Vector2.zero);
//            return;
//        }

//        // Arrived to waypoint
//        float distance = Vector2.Distance(rigidbody.position, path.vectorPath[currentWaypoint]);
//        if (distance <= nextWaypointDistance)
//        {
//            currentWaypoint++;
//            if (currentWaypoint == path.vectorPath.Count)
//                currentWaypoint--;
//        }

//        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rigidbody.position);
//        print(direction);
//        animator.SetOrientation(direction);

//        rigidbody.MovePosition(rigidbody.position + direction * Time.fixedDeltaTime * speed);
//        animator.Move(new Vector2(1, 1));
//    }

//    private void UpdatePath()
//    {
//        if (seeker.IsDone())
//            seeker.StartPath(transform.position, player.position, OnPathComplete);
//    }

//    void OnPathComplete(Path p)
//    {
//        path = p;
//        currentWaypoint = 0;
//    }
//}

using UnityEngine;
using UnityEngine.AI;

public class DodoMovement : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;
    CharacterAnimation animator;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<CharacterAnimation>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        agent.SetDestination(target.position);

        // Fix z axis to 0
        transform.position = new Vector2(transform.position.x, transform.position.y);

        if(!agent.velocity.normalized.Equals(Vector2.zero))
        {
            animator.SetOrientation(agent.velocity.normalized);
        }
        animator.Move(agent.velocity.normalized);
    }
}