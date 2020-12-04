using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject hud = null;
    [SerializeField] GameObject dialogueBox = null;
    [SerializeField] Text dialogueName = null;
    [SerializeField] Text dialogueText = null;

    readonly Queue<string> sentences = new Queue<string>();
    readonly Queue<Dialogue.sentenceAction> sentenceActions = new Queue<Dialogue.sentenceAction>();
    DialogueTrigger currentDialogueTrigger;
    static bool inDialogue = false;

    LanceIncendie lanceIncendie;
    Inventory inventory;

    private void Start()
    {
        dialogueBox.SetActive(false);
        lanceIncendie = FindObjectOfType<LanceIncendie>();
        inventory = FindObjectOfType<Inventory>();
    }

    public void StartDialogue(DialogueTrigger dialogueTrigger)
    {
        DisableControl();
        inDialogue = true;
        currentDialogueTrigger = dialogueTrigger;
        sentences.Clear();
        sentenceActions.Clear();

        foreach (string sentence in dialogueTrigger.dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach (Dialogue.sentenceAction action in dialogueTrigger.dialogue.sentenceActions)
        {
            sentenceActions.Enqueue(action);
        }

        hud.SetActive(false);
        dialogueBox.SetActive(true);
        dialogueName.text = dialogueTrigger.dialogue.name;

        NextSentence();
    }

    public void NextSentence()
    {

        if(currentDialogueTrigger.dialogue.actionsEnabled)
        {
            if (sentenceActions.Count == 0)
            {
                EndDialogue();
                return;
            }

            Dialogue.sentenceAction action = sentenceActions.Dequeue();
            dialogueText.text = action.sentence;
            action.sentenceEvent.Invoke();
        }
        else
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

            string sentence = sentences.Dequeue();
            dialogueText.text = sentence;
        }
    }

    private void EndDialogue()
    {
        EnableControl();
        hud.SetActive(true);
        dialogueBox.SetActive(false);
        inDialogue = false;

        currentDialogueTrigger.DialogueEnd();
    }

    private void EnableControl()
    {
        Time.timeScale = 1;
        lanceIncendie.gameObject.SetActive(true);
        inventory.gameObject.SetActive(true);
        MouseAspect.ChangeAspect(MouseAspect.Aspect.Default);
    }

    private void DisableControl()
    {
        Time.timeScale = 0;
        lanceIncendie.gameObject.SetActive(false);
        inventory.gameObject.SetActive(false);
        MouseAspect.ChangeAspect(MouseAspect.Aspect.Mouse);
    }

    public static bool IsInDialogue()
    {
        return inDialogue;
    }
}
