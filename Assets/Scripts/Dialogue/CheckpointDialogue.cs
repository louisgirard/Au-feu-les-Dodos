using UnityEngine;

public class CheckpointDialogue : DialogueTrigger
{
    bool walkedOnCheckpoint = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!walkedOnCheckpoint && collision.CompareTag("Player"))
        {
            walkedOnCheckpoint = true;
            DialogueStart();
        }
    }
}
