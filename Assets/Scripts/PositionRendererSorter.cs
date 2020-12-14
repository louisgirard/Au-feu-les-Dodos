using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteInEditMode]
public class PositionRendererSorter : MonoBehaviour
{
    public float offset = 0f;
    readonly float timeBetweenCalculation = 0.01f;
    protected readonly float precision = 100;

    protected SpriteRenderer spriteRenderer;
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

    private void Update()
    {
        if (Application.isEditor)
        {
            UpdateSortingOrder();
        }
    }

    protected IEnumerator LoopUpdateSortingOrder()
    {
        while (true)
        {
            UpdateSortingOrder();

            yield return new WaitForSeconds(timeBetweenCalculation);
        }
    }

    protected virtual void UpdateSortingOrder()
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
