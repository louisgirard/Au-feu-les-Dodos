using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Weapon : MonoBehaviour
{
    [Tooltip("0 means unique usage weapon")] [SerializeField] float timeBeforeOverheat = 4f;
    [SerializeField] float overheatingTime = 1f;
    [SerializeField] string fireKey = "Fire2";

    float timer;
    bool isOverheating = false;

    private void Awake()
    {
        timer = timeBeforeOverheat;
    }

    void Update()
    {
        if(isOverheating)
        {
            // Increase timer until the end of overheating
            timer += Time.deltaTime;
            if (timer >= overheatingTime)
            {
                isOverheating = false;
                timer = timeBeforeOverheat;
            }
            return;
        }

        if(CrossPlatformInputManager.GetButton(fireKey))
        {
            Fire();
            timer -= Time.deltaTime;

            // Unique usage weapon
            if (timeBeforeOverheat == 0)
            {
                isOverheating = true;
                StopFire();
            }
            else if (timer <= 0)
            {
                isOverheating = true;
                StopFire();
            }
        }
        else
        {
            StopFire();
        }
    }

    public virtual void Fire()
    {
    }

    public virtual void StopFire()
    {
    }
}
