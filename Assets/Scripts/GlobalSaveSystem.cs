using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSaveSystem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SavePlayerSystem savePlayer = (SavePlayerSystem)FindObjectOfType(typeof(SavePlayerSystem));
        SaveDodoSystem saveDodo = (SaveDodoSystem)FindObjectOfType(typeof(SaveDodoSystem));


        if (collision.CompareTag("Player"))
        {
            savePlayer.SavePlayer();
            saveDodo.SaveDodo();
            
        }
    }
}
