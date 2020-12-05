using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    int testCheckpoint = 0;

    SavePlayerSystem savePlayer;
    SaveDodoSystem saveDodo;

    PlayerEnjoyment playerEnjoyment;
    DodoHealth dodoHealth;

    AudioSource audioSource;

    private void Start()
    {
        savePlayer = FindObjectOfType<SavePlayerSystem>();
        saveDodo = FindObjectOfType<SaveDodoSystem>();
        playerEnjoyment = FindObjectOfType<PlayerEnjoyment>();
        dodoHealth = FindObjectOfType<DodoHealth>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().color = new Color(0f, 0.6f, 0.7f);
            savePlayer.SavePlayer();
            saveDodo.SaveDodo();
            if (testCheckpoint == 0)
            {
                playerEnjoyment.AddEnjoyment(playerEnjoyment.maxEnjoyment);
                dodoHealth.Heal(dodoHealth.maxHealth);
            }
            testCheckpoint++;
            audioSource.Play();
        }
    }
}
