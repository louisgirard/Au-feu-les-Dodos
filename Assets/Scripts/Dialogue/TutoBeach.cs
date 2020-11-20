using UnityEngine;

public class TutoBeach : DialogueTrigger
{
    bool dialogueStarted = false;

    void Start()
    {
        Invoke(nameof(StartDialogue), .1f);
    }

    private void StartDialogue()
    {
        if (!dialogueStarted)
        {
            DialogueStart();
            dialogueStarted = true;
            CharacterAnimation player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterAnimation>();
            player.SetOrientation(Vector2.up);
            player.Move(Vector2.zero);
        }
    }

    public override void DialogueEnd()
    {

    }
}
