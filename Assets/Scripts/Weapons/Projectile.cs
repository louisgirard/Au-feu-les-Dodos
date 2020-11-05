using UnityEngine;

[RequireComponent(typeof(WaterBombExplosion))]
public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 2f;

    Vector2 destination;
    WaterBombExplosion bombExplosion;

    private void Start()
    {
        bombExplosion = GetComponent<WaterBombExplosion>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        if (IsArrivedAtDestination())
        {
            bombExplosion.StartTimer();
        }
    }

    private bool IsArrivedAtDestination()
    {
        return Vector2.Distance(transform.position, destination) <= 0.01f;
    }

    public void SetDestination(Vector2 finalDestination)
    {
        destination = finalDestination;
    }
}
