using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject hud = null;
    [SerializeField] GameObject dialogueInterface = null;
    [SerializeField] Text dialogueName = null;
    [SerializeField] Text dialogueText = null;

    Queue<string> sentences = new Queue<string>();
    DialogueTrigger currentDialogueTrigger;

    GameObject player;
    LanceIncendie lanceIncendie;
    Inventory inventory;

    private void Start()
    {
        dialogueInterface.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        lanceIncendie = FindObjectOfType<LanceIncendie>();
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
        dialogueInterface.SetActive(true);
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

    IEnumerator DisplayDialogue()
    {
        while(sentences.Count > 0)
        {
            NextSentence();
            yield return new WaitForSeconds(2f);
        }
        EndDialogue();
    }

    private void EndDialogue()
    {
        EnableControl();
        hud.SetActive(true);
        dialogueInterface.SetActive(false);

        currentDialogueTrigger.DialogueEnd();
    }

    private void EnableControl()
    {
        player.GetComponent<PlayerMovement>().EnableControl();
        player.GetComponent<PlayerEnjoyment>().timerEnabled = true;
        lanceIncendie.gameObject.SetActive(true);
        inventory.gameObject.SetActive(true);
    }

    private void DisableControl()
    {
        player.GetComponent<PlayerMovement>().DisableControl();
        player.GetComponent<PlayerEnjoyment>().timerEnabled = false;
        lanceIncendie.gameObject.SetActive(false);
        inventory.gameObject.SetActive(false);
    }
}
