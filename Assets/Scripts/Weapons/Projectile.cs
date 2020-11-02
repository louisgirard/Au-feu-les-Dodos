using UnityEngine;

[RequireComponent(typeof(WaterBombExplosion))]
public class Projectile : MonoBehaviour
{
    Vector2 destination;
    WaterBombExplosion bombExplosion;

    private void Start()
    {
        bombExplosion = GetComponent<WaterBombExplosion>();
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, destination, 2);

        if(IsArrivedAtDestination())
        {
            bombExplosion.StartTimer();
        }
    }

    private bool IsArrivedAtDestination()
    {
        return Vector2.Distance(transform.position, destination) <= 0.5f;
    }

    public void SetDestination(Vector2 finalDestination)
    {
        destination = finalDestination;
    }
}
