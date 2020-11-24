using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EctoplasmaStartFight : DialogueTrigger
{
    public Vector2 dodo_waiting_position;
    public GameObject blockFire;

    public bool fighting { get; set; }

    void Start()
    {
        ResetBattle();
    }

    public void StartFight()
    {
        if (!fighting)
        {
            fighting = true;
            if (blockFire) blockFire.SetActive(true);

            GetComponent<EctoplasmaLife>().StartFight();
            GetComponent<Animator>().SetTrigger("Start");
            GetComponent<Burning>().enabled = true;

            PlayerEnjoyment playerEnjoyment = (PlayerEnjoyment)FindObjectOfType(typeof(PlayerEnjoyment));
            playerEnjoyment.currentEnjoyment = playerEnjoyment.maxEnjoyment;
            playerEnjoyment.ActiveTime(false);

            GameObject.FindWithTag("Dodo").transform.position = dodo_waiting_position;
            GameObject.FindWithTag("DodoToSave").transform.position = dodo_waiting_position + new Vector2(0.5f, 0.2f);
            SetDodoActive(false);
        }
    }

    public override void DialogueEnd()
    {
        StartFight();
    }

    public void ResetBattle()
    {
        GetComponent<Animator>().SetTrigger("Stop");
        if (blockFire) blockFire.SetActive(false);
        GetComponent<EctoplasmaLife>().StopFight();
        fighting = false;

        SetDodoActive(true);

        PlayerEnjoyment playerEnjoyment = (PlayerEnjoyment)FindObjectOfType(typeof(PlayerEnjoyment));
        playerEnjoyment.currentEnjoyment = playerEnjoyment.maxEnjoyment;
        playerEnjoyment.ActiveTime(true);
    }

    void SetDodoActive(bool val)
    {
        GameObject dodo = GameObject.FindWithTag("Dodo");
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
}
