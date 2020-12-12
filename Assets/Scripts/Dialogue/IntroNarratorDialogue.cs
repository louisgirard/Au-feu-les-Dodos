using UnityEngine.SceneManagement;
using UnityEngine;

public class IntroNarratorDialogue : DialogueTrigger
{
    private void Start()
    {
        Invoke("DialogueStart", 0.1f);
    }

    public void EndScene()
    {
        SceneManager.LoadScene(1);
    }
}
