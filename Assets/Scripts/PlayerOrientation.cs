using UnityEngine;

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
        Vector3 mousePosition = Input.mousePosition;

        // Mouse origin at the center of the screen
        mousePosition.x -= Screen.width / 2;
        mousePosition.y -= Screen.height / 2;

        // Update Orientation
        playerAnimation.SetOrientation(new Vector2(mousePosition.x, mousePosition.y).normalized);
    }
}
