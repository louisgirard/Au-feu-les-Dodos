using System.Collections;
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
    DialogueTrigger currentDialogueTrigger;

    GameObject player;
    Inventory inventory;

    private void Start()
    {
        dialogueBox.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = FindObjectOfType<Inventory>();
    }

    public void StartDialogue(DialogueTrigger dialogueTrigger)
    {
        DisableControl();
        currentDialogueTrigger = dialogueTrigger;
        sentences.Clear();

        foreach (string sentence in dialogueTrigger.dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        hud.SetActive(false);
        dialogueBox.SetActive(true);
        dialogueName.text = dialogueTrigger.dialogue.name;

        NextSentence();
    }

    public void NextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    private void EndDialogue()
    {
        EnableControl();
        hud.SetActive(true);
        dialogueBox.SetActive(false);

        currentDialogueTrigger.DialogueEnd();
    }

    private void EnableControl()
    {
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerEnjoyment>().enabled = true;
        player.GetComponent<PlayerOrientation>().enabled = true;
        player.GetComponentInChildren<LanceIncendie>().enabled = true;
        inventory.gameObject.SetActive(true);
        player.GetComponent<MouseAspect>().ChangeAspect(MouseAspect.Aspect.Default);
    }

    private void DisableControl()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<PlayerEnjoyment>().enabled = false;
        player.GetComponent<PlayerOrientation>().enabled = false;
        player.GetComponentInChildren<LanceIncendie>().enabled = false;
        inventory.gameObject.SetActive(false);
        player.GetComponent<MouseAspect>().ChangeAspect(MouseAspect.Aspect.Mouse);
    }
}
