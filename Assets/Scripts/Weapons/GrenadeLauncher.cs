using UnityEngine;

public class GrenadeLauncher : Weapon
{
    [SerializeField] Projectile projectilePrefab = null;
    [SerializeField] float range = 2f;

    private void Start()
    {
        DrawCircle();
    }

    public override void Fire()
    {
        base.Fire();
        Projectile projectile;

        projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        Vector2 destination = CursorPosition.ToWorld();
        print(Vector2.Distance(transform.position, destination));
        if (Vector2.Distance(transform.position, destination) > range)
        {
            print("out of range");
            destination = (Vector2)transform.position + CursorPosition.Position().normalized * (range);
        }
        projectile.SetDestination(destination);
    }

    private void DrawCircle()
    {
        LineRenderer line = GetComponent<LineRenderer>();
        line.positionCount = 40;
        float radius = range + range / 3.33f;
        float angle = 20f;

        for (int i = 0; i < line.positionCount; i++)
        {
            Vector3 position = new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle) * radius, Mathf.Cos(Mathf.Deg2Rad * angle) * radius, 0f);
            line.SetPosition(i, position);

            angle += (360f / line.positionCount);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
        print("gizmos draw circle");
    }
}
