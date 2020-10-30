using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(BoxCollider2D))]
public class MouseAspect : MonoBehaviour
{
    public Texture2D cursorTexture;
    public Texture2D defaultTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private void Update()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }
        else
        {
            Cursor.SetCursor(defaultTexture, hotSpot, cursorMode);
        }
    }
}
