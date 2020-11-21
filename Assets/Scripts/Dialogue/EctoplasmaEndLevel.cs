using UnityEngine.SceneManagement;
using UnityEngine;

public class EctoplasmaEndLevel : DialogueTrigger
{
    bool dialogueStarted = false;

    public void StartDialogue()
    {
        if(!dialogueStarted)
        {
            DisableControl();
            DialogueStart();
            dialogueStarted = true;
        }
    }

    public override void DialogueEnd()
    {
        Invoke(nameof(NextLevel), 1);
        gameObject.SetActive(false);
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(0);
    }

    private void DisableControl()
    {
        GetComponent<Burning>().enabled = false;
        GetComponent<Animator>().SetTrigger("Stop");
    }
}
