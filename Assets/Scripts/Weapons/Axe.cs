using UnityEngine;
using UnityEngine.Rendering;

public class Axe : Weapon
{
    [SerializeField] GameObject axeHitPrefab = null;
    readonly float weaponRange = 0.7f;

    public override void Fire()
    {
        base.Fire();
        int layerMask = 1 << 8;

        Vector2 cursorPosition = CursorPosition.Position();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, cursorPosition, weaponRange, layerMask);

        if (hit.collider != null)
        {
            GameObject axeHit = Instantiate(axeHitPrefab, hit.transform.position, axeHitPrefab.transform.rotation);
            if(hit.collider.GetComponent<SpriteRenderer>())
            {
                axeHit.GetComponent<SpriteRenderer>().sortingOrder = hit.collider.GetComponent<SpriteRenderer>().sortingOrder + 1;
            }
            else if (hit.collider.GetComponent<SortingGroup>())
            {
                axeHit.GetComponent<SpriteRenderer>().sortingOrder = hit.collider.GetComponent<SortingGroup>().sortingOrder + 1;
            }
            Destroy(axeHit, 0.2f);

            hit.collider.GetComponent<StumpDestruction>().TakeDamage(1);
        }
    }
}
