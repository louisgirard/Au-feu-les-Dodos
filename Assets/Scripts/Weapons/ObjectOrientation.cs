using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ObjectOrientation : MonoBehaviour
{
    void Update()
    {
        Vector2 cursorPosition = CursorPosition.Position();

        float angle = Vector2.Angle(new Vector2(1, 0), cursorPosition);
        if(cursorPosition.y < 0)
        {
            angle = -angle;
        }

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
