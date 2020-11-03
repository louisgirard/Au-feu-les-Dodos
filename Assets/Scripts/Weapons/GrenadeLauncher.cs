using UnityEngine;

public class GrenadeLauncher : Weapon
{
    [SerializeField] Projectile projectilePrefab = null;
    [SerializeField] float range = 10f;

    private void Start()
    {
        DrawCircle();
    }

    public override void Fire()
    {
        Projectile projectile;

        projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        Vector2 destination = CursorPosition.ToWorld();
        if (Vector2.Distance(transform.position, destination) > range)
        {
            destination = (Vector2)transform.position + CursorPosition.Position().normalized * range;
        }
        projectile.SetDestination(destination);
    }

    private void DrawCircle()
    {
        int vertexCount = 40;
        LineRenderer lineRenderer = GetComponent<LineRenderer>();

        float deltaTheta = (2f * Mathf.PI) / vertexCount;
        float theta = 0f;

        lineRenderer.positionCount = vertexCount;

        for(int i = 0; i < lineRenderer.positionCount; i++)
        {
            Vector3 pos = new Vector3(range * Mathf.Cos(theta), range * Mathf.Sin(theta), 0f);
            lineRenderer.SetPosition(i, pos);
            theta += deltaTheta;
        }
    }
}
