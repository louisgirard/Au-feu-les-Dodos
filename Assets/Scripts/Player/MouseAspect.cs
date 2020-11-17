using UnityEngine;

public class MouseAspect : MonoBehaviour
{
    public enum Aspect { Fire, Default, Mouse };

    [SerializeField] Texture2D fireTexture = null;
    [SerializeField] Texture2D defaultTexture = null;
    [SerializeField] Texture2D mouseTexture = null;

    private void Start()
    {
        ChangeAspect(Aspect.Default);
    }

    public void ChangeAspect(Aspect texture)
    {
        switch (texture)
        {
            case Aspect.Default:
                Cursor.SetCursor(defaultTexture, Vector2.zero, CursorMode.Auto);
                break;
            case Aspect.Fire:
                Cursor.SetCursor(fireTexture, Vector2.zero, CursorMode.Auto);
                break;
            case Aspect.Mouse:
                Cursor.SetCursor(mouseTexture, Vector2.zero, CursorMode.Auto);
                break;
        }
    }
}
