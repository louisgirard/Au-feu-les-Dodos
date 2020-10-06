using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(CharacterAnimation))]
public class PlayerOrientation : MonoBehaviour
{
    CharacterAnimation playerAnimation;

    void Start()
    {
        playerAnimation = GetComponent<CharacterAnimation>();
    }

    void Update()
    {
        Vector3 mousePosition = CrossPlatformInputManager.mousePosition;

        // Mouse origin at the center of the screen
        mousePosition.x -= Screen.width / 2;
        mousePosition.y -= Screen.height / 2;

        // Joystick input
        float xInput = CrossPlatformInputManager.GetAxisRaw("Horizontal aim");
        float yInput = -CrossPlatformInputManager.GetAxisRaw("Vertical aim");

        // Update Orientation
        if (xInput == 0 && yInput == 0)
            playerAnimation.SetOrientation(new Vector2(mousePosition.x, mousePosition.y).normalized);
        else
            playerAnimation.SetOrientation(new Vector2(xInput, yInput).normalized);
    }
}
