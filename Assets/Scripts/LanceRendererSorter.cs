using UnityEngine;
using UnityEngine.Rendering;

public class LanceRendererSorter : PositionRendererSorter
{
    [SerializeField] SpriteRenderer player = null;

    protected override void UpdateSortingOrder()
    {
        Vector2 cursorPosition = CursorPosition.Position();
        if(cursorPosition.y > 0)
        {
            spriteRenderer.sortingOrder = player.sortingOrder - 10;
        }
        else
        {
            spriteRenderer.sortingOrder = player.sortingOrder + 10;
        }
    }

    private void OnEnable()
    {
        if (!spriteRenderer) return;
        StartCoroutine(LoopUpdateSortingOrder());
    }
}
