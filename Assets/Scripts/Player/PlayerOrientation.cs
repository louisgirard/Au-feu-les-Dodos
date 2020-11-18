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
        Vector2 cursorPosition = CursorPosition.Position();

        playerAnimation.SetOrientation(cursorPosition);
    }
}
