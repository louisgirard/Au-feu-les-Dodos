using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoBeach : DialogueTrigger
{
    bool dialogueStarted = false;

    void Start()
    {
        Invoke("StartDialogue", .1f);
    }

    private void StartDialogue()
    {
        if (!dialogueStarted)
        {
            DialogueStart();
            dialogueStarted = true;
        }
    }

    public override void DialogueEnd()
    {

    }
}
