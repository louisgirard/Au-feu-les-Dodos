using UnityEngine;

public class DodoWeakDialogue : DialogueTrigger
{
    DodoHealth dodoHealth;
    bool dialogueStarted = false;

    private void Start()
    {
        dodoHealth = FindObjectOfType<DodoHealth>();
    }

    private void Update()
    {
        if(dodoHealth.IsDying() && !dialogueStarted)
        {
            dialogueStarted = true;
            DialogueStart();
        }
    }

    public override void DialogueEnd()
    {
        FindObjectOfType<DodoUI>().ResetHead();
        Destroy(gameObject);
    }
}
