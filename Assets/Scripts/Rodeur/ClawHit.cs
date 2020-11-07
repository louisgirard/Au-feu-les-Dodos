using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawHit : MonoBehaviour
{
    private GameObject player = null;
    private GameObject dodo = null;
    private PlayerEnjoyment playerEnjoyment;
    private Vector3 start_position;
    private Vector3 target_position;
    private float timer;

    private void Start()
    {
        playerEnjoyment = (PlayerEnjoyment)FindObjectOfType(typeof(PlayerEnjoyment));
        timer = 1;
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
