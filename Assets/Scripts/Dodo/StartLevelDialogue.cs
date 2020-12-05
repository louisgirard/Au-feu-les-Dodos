using UnityEngine;

public class StartLevelDialogue : DialogueTrigger
{
    bool dialogue_started = false;

    void Start()
    {
        Invoke("StartDialogue", 0.1f);
        dialogue.name = GameObject.FindWithTag("Dodo").name.Replace("(Clone)","");
    }

    void StartDialogue()
    {
        if (!dialogue_started)
        {
            DialogueStart();
            dialogue_started = true;
            CharacterAnimation player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterAnimation>();
            player.SetOrientation(Vector2.left);
            player.Move(Vector2.zero);
        }
    }

    public override void DialogueEnd()
    {
        Destroy(gameObject);
    }
}
