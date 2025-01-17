﻿using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue = null;

    protected void DialogueStart()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(this);
    }

    public virtual void NextSentence(int sentence) { }

    public virtual void DialogueEnd() { }
}
