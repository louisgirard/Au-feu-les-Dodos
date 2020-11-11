using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EctoplasmaExplosion : MonoBehaviour
{
    private PlayerEnjoyment playerEnjoyment;

    private void Start()
    {
        playerEnjoyment = FindObjectOfType<PlayerEnjoyment>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerEnjoyment.TakeDamage("Ectoplasma proximity explosion");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dodo"))
            collision.GetComponentInChildren<DodoHealth>().TakeDamage(1);
    }
}
