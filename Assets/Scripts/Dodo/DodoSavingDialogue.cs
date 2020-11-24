using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodoSavingDialogue : DialogueTrigger
{
    private bool saved = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!saved && collision.CompareTag("Player"))
        {
            saved = true;
            DialogueStart();
        }
    }

    public override void DialogueEnd()
    {
        GameObject.FindWithTag("Ectoplasma").GetComponent<EctoplasmaStartFight>().StartDialogue();
    }
    
}
