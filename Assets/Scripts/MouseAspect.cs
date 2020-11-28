using UnityEngine;

public class MouseAspect : MonoBehaviour
{
    public enum Aspect { Fire, Default, Mouse };

    [SerializeField] Texture2D refToFireTexture = null;
    [SerializeField] Texture2D refToDefaultTexture = null;
    [SerializeField] Texture2D refToMouseTexture = null;

    static Texture2D fireTexture = null;
    static Texture2D defaultTexture = null;
    static Texture2D mouseTexture = null;

    static Aspect currentAspect;

    private void Awake()
    {
        fireTexture = refToFireTexture;
        defaultTexture = refToDefaultTexture;
        mouseTexture = refToMouseTexture;
        ChangeAspect(Aspect.Default);
    }

    public static void ChangeAspect(Aspect texture)
    {
        currentAspect = texture;
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

    public static Aspect CurrentAspect()
    {
        return currentAspect;
    }
}
