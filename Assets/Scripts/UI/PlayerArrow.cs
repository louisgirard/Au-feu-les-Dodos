using UnityEngine;

public class PlayerArrow : MonoBehaviour
{
    private void Update()
    {
        Vector2 cursorPosition = CursorPosition.Position();

        float angle = Vector2.Angle(new Vector2(0, 1), cursorPosition);
        if (cursorPosition.x > 0)
        {
            angle = -angle;
        }

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
