using UnityEngine;

public class DodoSavingDialogue : DialogueTrigger
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DialogueStart();
        }
    }

    public override void DialogueEnd()
    {
        GameObject.FindWithTag("Ectoplasma").GetComponent<EctoplasmaStartFight>().StartDialogue();
    }
    
}
