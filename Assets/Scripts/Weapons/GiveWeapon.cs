using UnityEngine;

public class GiveWeapon : MonoBehaviour
{
    public Weapon weapon;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Inventory inventory = (Inventory)FindObjectOfType(typeof(Inventory));
        if (collision.CompareTag("Player"))
        {
            inventory.AddWeapon(weapon);
        }
    }
}
