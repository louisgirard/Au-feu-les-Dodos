﻿using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimation : MonoBehaviour
{
    string[] idlePositions = { "Idle Down", "Idle Up", "Idle Left", "Idle Right" };
    string[] walkPositions = { "Walk Down", "Walk Up", "Walk Left", "Walk Right" };
    string[] attackPositions = { "Attack Down", "Attack Up", "Attack Left", "Attack Right" };
    Animator animator;
    int direction;
    string animationPlaying;

    private void Start()
    {
        animationPlaying = idlePositions[0];
        animator = GetComponent<Animator>();
    }

    public void SetOrientation(Vector2 mouseDirection)
    {
        direction = DirectionToIndex(mouseDirection);
    }

    // Play move/idle animation
    public void Move(Vector2 moveVector)
    {
        if(moveVector.Equals(Vector2.zero))
        {
            if(!AnimatorIsPlaying())
            {
                animationPlaying = idlePositions[direction];
                animator.Play(animationPlaying);
            }
        }
        else
        {
            if (!AnimatorIsPlaying())
            {
                animationPlaying = walkPositions[direction];
                animator.Play(animationPlaying);
            }
        }
    }

    // Play attack animation
    public void Attack()
    {
        if (!AnimatorIsPlaying())
            animator.Play(attackPositions[direction]);
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

    bool AnimatorIsPlaying()
    {
        return animator.GetCurrentAnimatorStateInfo(0).length >
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    public string Animation()
    {
        return animationPlaying;
    }
}
