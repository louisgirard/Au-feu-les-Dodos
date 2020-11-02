﻿using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public static class CursorPosition
{
    public static Vector2 Position()
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
            return new Vector2(mousePosition.x, mousePosition.y).normalized;
        else
            return new Vector2(xInput, yInput).normalized;
    }
}
