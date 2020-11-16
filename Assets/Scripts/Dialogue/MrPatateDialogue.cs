using UnityEngine;

public class MrPatateDialogue : DialogueTrigger
{
    [SerializeField] Weapon weaponToGive = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            DialogueStart();
        }
    }

    public override void DialogueEnd()
    {
        FindObjectOfType<Inventory>().AddWeapon(weaponToGive);
        Destroy(gameObject, 1f);
    }
}
