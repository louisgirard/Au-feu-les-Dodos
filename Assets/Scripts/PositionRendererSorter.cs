using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class PositionRendererSorter : MonoBehaviour
{
    [SerializeField] float offset = 0f;
    readonly float timeBetweenCalculation = 0.01f;
    readonly float precision = 100;

    SpriteRenderer spriteRenderer;
    SortingGroup sortingGroup;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        sortingGroup = GetComponent<SortingGroup>();
        if (gameObject.isStatic)
        {
            UpdateSortingOrder();
        }
        else
        {
            StartCoroutine(LoopUpdateSortingOrder());
        }
    }

    IEnumerator LoopUpdateSortingOrder()
    {
        while (true)
        {
            UpdateSortingOrder();

            yield return new WaitForSeconds(timeBetweenCalculation);
        }
    }

    private void UpdateSortingOrder()
    {
        if(sortingGroup == null)
        {
            spriteRenderer.sortingOrder = (int)((-transform.position.y + offset) * precision);
        }
        else
        {
            sortingGroup.sortingOrder = (int)((-transform.position.y + offset) * precision);
        }
    }
}
