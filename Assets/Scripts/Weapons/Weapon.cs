using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Weapon : MonoBehaviour
{
    [Tooltip("0 means unique usage weapon")] [SerializeField] float timeBeforeOverheat = 4f;
    [SerializeField] float overheatingTime = 1f;
    [SerializeField] string fireKey = "Fire2";
    [SerializeField] Sprite icon = null;

    float timer;
    bool isOverheating = false;

    private void Awake()
    {
        timer = timeBeforeOverheat;
    }

    void Update()
    {
        Orientation();

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
            timer = Mathf.Min(timer + Time.deltaTime, timeBeforeOverheat);
            StopFire();
        }
    }

    private void Orientation()
    {
        Vector2 cursorPosition = CursorPosition.Position();

        float angle = Vector2.Angle(new Vector2(1, 0), cursorPosition);
        if (cursorPosition.y < 0)
        {
            angle = -angle;
        }

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public virtual void Fire()
    {
    }

    public virtual void StopFire()
    {
    }

    public Sprite GetIcon()
    {
        return icon;
    }

    public float GetOverheatingTimerRatio()
    {
        if (!isOverheating) return 0;
        return 1 - (timer / overheatingTime);
    }
}
