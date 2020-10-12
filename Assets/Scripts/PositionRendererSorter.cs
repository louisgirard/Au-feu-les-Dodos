using System.Collections;
using UnityEngine;

public class PositionRendererSorter : MonoBehaviour
{
    [SerializeField] float offset = 0f;
    float timeBetweenCalculation = 0.01f;

    float precision = 100;

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (gameObject.isStatic)
        {
            UpdateSortingOrder();
        }
        else
        {
            StartCoroutine(UpdateSortingLayer());
        }
    }

    IEnumerator UpdateSortingLayer()
    {
        while (true)
        {
            UpdateSortingOrder();

            yield return new WaitForSeconds(timeBetweenCalculation);
        }
    }

    private void UpdateSortingOrder()
    {
        spriteRenderer.sortingOrder = (int)((-transform.position.y + offset) * precision);
    }
}
