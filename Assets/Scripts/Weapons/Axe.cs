using UnityEngine;

public class Axe : Weapon
{
    private float weaponRange = 1f;
    public override void Fire()
    {
        int layerMask = 1 << 8;

        Vector2 cursorPosition = CursorPosition.Position();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, cursorPosition, weaponRange, layerMask);

        if (hit.collider != null)
        {
            hit.collider.GetComponent<Destruction>().TakeDamage(1);
        }
    }
}
