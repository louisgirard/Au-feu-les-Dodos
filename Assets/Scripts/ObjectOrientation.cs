using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ObjectOrientation : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePosition = CrossPlatformInputManager.mousePosition;

        mousePosition.x -= Screen.width / 2;
        mousePosition.y -= Screen.height / 2;

        float xInput = CrossPlatformInputManager.GetAxisRaw("Horizontal aim");
        float yInput = -CrossPlatformInputManager.GetAxisRaw("Vertical aim");

        Vector2 mouse2D = new Vector2(mousePosition.x, mousePosition.y);

        float angle = Vector2.Angle(new Vector2(1, 0), mouse2D);
        if(mouse2D.y < 0)
        {
            angle = -angle;
        }

        // Update Orientation
        if (xInput == 0 && yInput == 0)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        else
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
