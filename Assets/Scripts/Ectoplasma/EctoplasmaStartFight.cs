using UnityEngine;
using UnityEngine.AI;

public class EctoplasmaStartFight : DialogueTrigger
{
    public GameObject blockFire;

    public bool fighting { get; set; }

    public MenuSettings menuSettings;
    private PlayMusic playMusic;

    private GameObject dodo;
    private GameObject dodoToSave;

    void Start()
    {
        playMusic = FindObjectOfType<PlayMusic>();
        dodo = GameObject.FindGameObjectWithTag("Dodo");
        dodoToSave = GameObject.FindGameObjectWithTag("DodoToSave");
        ResetBattle();
    }

    public void StartFight()
    {
        if (!fighting)
        {
            fighting = true;
            if (blockFire) blockFire.SetActive(true);

            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Burning>().enabled = true;
            GetComponent<EctoplasmaLife>().StartFight();
            GetComponent<Animator>().SetTrigger("Start");
            GetComponent<Burning>().enabled = true;

            PlayerEnjoyment playerEnjoyment = FindObjectOfType<PlayerEnjoyment>();
            playerEnjoyment.ActiveTime(false);

            SetDodoActive(false);
            dodoToSave.SetActive(false);

            StartMusicFight();
        }
    }

    public override void DialogueEnd()
    {
        StartFight();
    }

    public void ResetBattle()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Burning>().enabled = false;
        GetComponent<Animator>().SetTrigger("Stop");
        if (blockFire) blockFire.SetActive(false);
        GetComponent<EctoplasmaLife>().StopFight();
        fighting = false;

        SetDodoActive(true);
        dodoToSave.SetActive(true);

        PlayerEnjoyment playerEnjoyment = FindObjectOfType<PlayerEnjoyment>();
        playerEnjoyment.AddEnjoyment(playerEnjoyment.maxEnjoyment);
        playerEnjoyment.ActiveTime(true);
    }

    void SetDodoActive(bool val)
    {
        dodo.GetComponent<SpriteRenderer>().enabled = val;
        dodo.GetComponent<DodoAI>().enabled = val;
        dodo.GetComponent<DodoMovement>().enabled = val;
        dodo.GetComponent<NavMeshAgent>().enabled = val;
        if (!val)
            dodo.GetComponent<Animator>().Play("Idle Down");
        dodo.GetComponent<Collider2D>().enabled = val;
    }

    public void StartDialogue()
    {
        DialogueStart();
    }

    private void StartMusicFight()
    {
        playMusic.StopMusic();
        playMusic.PlaySelectedMusic(menuSettings.musicEctoplasmaFight);
    }
}
