using UnityEngine.SceneManagement;
using UnityEngine;

public class EctoplasmaEndLevel : DialogueTrigger
{
    bool dialogueStarted = false;

    public MenuSettings menuSettings;
    private PlayMusic playMusic;

    private void Start()
    {
        playMusic = FindObjectOfType<PlayMusic>();
    }

    public void StartDialogue()
    {
        if(!dialogueStarted)
        {
            DisableControl();
            DialogueStart();
            dialogueStarted = true;
            StartEndLevelMusic();
        }
    }

    public override void DialogueEnd()
    {
        PlayerEnjoyment playerEnjoyment = FindObjectOfType<PlayerEnjoyment>();
        playerEnjoyment.AddEnjoyment(playerEnjoyment.maxEnjoyment);
        Invoke(nameof(NextLevel), 1);
        gameObject.SetActive(false);
    }

    private void NextLevel()
    {
        if (CrossSceneInformation.nextLevel == 4)
        {
            SceneManager.LoadScene(6);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    private void DisableControl()
    {
        GetComponent<Burning>().enabled = false;
        GetComponent<Animator>().SetTrigger("Stop");
    }

    private void StartEndLevelMusic()
    {
        playMusic.StopMusic();
        playMusic.PlaySelectedMusic(menuSettings.musicEndLevel);
    }
}
