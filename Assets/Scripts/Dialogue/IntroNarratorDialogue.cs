using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroNarratorDialogue : DialogueTrigger
{
    private void Start()
    {
        Invoke("DialogueStart", 0.1f);
    }
}
