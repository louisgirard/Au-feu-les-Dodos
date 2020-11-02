using UnityEngine;

public class WaterBombExplosion : MonoBehaviour
{
    [SerializeField] float timeBeforeExplosion = 0f;
    [SerializeField] ParticleSystem waterExplosionPrefab = null;

    bool isTimerStarted = false;
    float timer;

    private void Start()
    {
        timer = timeBeforeExplosion;
    }

    void Update()
    {
        if(isTimerStarted)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                // explosion
                ParticleSystem waterExplosion = Instantiate(waterExplosionPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
                Destroy(waterExplosion.gameObject, waterExplosion.main.duration);
            }
        }
    }

    public void StartTimer()
    {
        isTimerStarted = true;
    }
}
