using UnityEngine;

public class DodoAI : MonoBehaviour
{
    enum Mode { Passive, Active };

    DodoMovement dodoMovement;
    DodoAttack dodoAttack;

    Transform currentTarget;
    Transform player;
    Mode mode = Mode.Passive;
    DodoHealth health;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentTarget = player;
        health = GetComponentInChildren<DodoHealth>();
        dodoMovement = GetComponent<DodoMovement>();
        dodoAttack = GetComponent<DodoAttack>();
    }

    private void Update()
    {
        // Fix z axis to 0
        transform.position = new Vector2(transform.position.x, transform.position.y);

        // Target dead, or dodo dying
        if (currentTarget == null || health.IsDying())
        {
            SetTarget(player);
            mode = Mode.Passive;
        }

        if (mode == Mode.Passive)
        {
            dodoMovement.MoveTo(currentTarget);
        }
        else if (mode == Mode.Active)
        {
            if (dodoAttack.InAttackRange())
            {
                dodoMovement.Stop();
                dodoAttack.Attack();
            }
            else
            {
                dodoMovement.MoveTo(currentTarget);
            }
        }
    }

    public void EnemyDetected(Transform enemy)
    {
        // Target in range, set new target
        if(mode == Mode.Passive)
        {
            mode = Mode.Active;
            SetTarget(enemy);
        }
        else if(mode == Mode.Active)
        {
            // Target null = dead then change target
            if (currentTarget == null)
            {
                SetTarget(enemy);
            }
            else
            {
                // Target not dead, check if new target is closer
                float distanceToCurrentTarget = Vector2.Distance(transform.position, currentTarget.position);
                float distanceToPotentialTarget = Vector2.Distance(transform.position, enemy.position);
                if (distanceToPotentialTarget < distanceToCurrentTarget)
                {
                    SetTarget(enemy);
                }
            }
        }
    }

    private void SetTarget(Transform target)
    {
        currentTarget = target;
        dodoAttack.SetTarget(ref currentTarget);
    }
}