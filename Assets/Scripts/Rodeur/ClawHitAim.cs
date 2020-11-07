using UnityEngine;

public class ClawHitAim : MonoBehaviour
{
    private Vector3 start_position;
    private Vector3 target_position;
    private float timer;

    private void Start()
    {
        timer = 0;
    }

    public void HitMove(Vector2 pos)
    {
        start_position = transform.localPosition;
        target_position = (pos - (Vector2)transform.parent.position) / transform.parent.localScale;
        timer = 0.001f;
    }

    private void Update()
    {
        if (timer > 0)
        {
            if (timer < 0.3f)
            {
                transform.localPosition = Vector3.Lerp(start_position, target_position, timer / 0.1f);
                timer += Time.deltaTime;
            }
            else if (timer < 0.333)
            {
                transform.localPosition = Vector3.Lerp(target_position, start_position, (timer-0.25f) / (0.333f-0.25f));
                timer += Time.deltaTime;
            }
            else
            {
                transform.localPosition = start_position;
                timer = 0;
            }
        }
    }
}
