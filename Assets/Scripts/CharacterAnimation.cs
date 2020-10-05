using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimation : MonoBehaviour
{
    string[] idlePositions = { "Idle Down", "Idle Up", "Idle Left", "Idle Right" };
    string[] walkPositions = { "Walk Down", "Walk Up", "Walk Left", "Walk Right" };
    Animator animator;
    int direction;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetOrientation(Vector2 mouseDirection)
    {
        direction = DirectionToIndex(mouseDirection);
    }

    // Play animation
    public void Move(Vector2 moveVector)
    {
        if(moveVector.Equals(Vector2.zero))
        {
            animator.Play(idlePositions[direction]);
        }
        else
        {
            animator.Play(walkPositions[direction]);
        }
    }
    
    // Returns a direction index depending on a direction (mouse position, joystick)
    private int DirectionToIndex(Vector2 direction)
    {
        float x = direction.x;
        float y = direction.y;

        // Right
        if(x >= 0 && x >= Mathf.Abs(y))
        {
            return 3;
        }
        // Left
        if (x <= 0 && -x >= Mathf.Abs(y))
        {
            return 2;
        }
        // Up
        if (y >= 0 && y >= Mathf.Abs(x))
        {
            return 1;
        }
        // Down
        if (y <= 0 && -y >= Mathf.Abs(x))
        {
            return 0;
        }
        return -1;
    }
}
