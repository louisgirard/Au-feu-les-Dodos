using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawHit : MonoBehaviour
{
    private GameObject player = null;
    private GameObject dodo = null;
    private PlayerEnjoyment playerEnjoyment;

    private void Start()
    {
        playerEnjoyment = (PlayerEnjoyment)FindObjectOfType(typeof(PlayerEnjoyment));
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            player = collision.gameObject;
        else if (collision.CompareTag("Dodo"))
            dodo = collision.gameObject;        
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            player = null;
        else if (collision.CompareTag("Dodo"))
            dodo = null;
    }

    public void AttackHitEvent()
    {
        if (dodo != null)
        {
            dodo.GetComponentInChildren<DodoHealth>().TakeDamage(2);
        }
        if (player != null)
        {
            playerEnjoyment.TakeDamage("Rodeur");
        }
    }
}
