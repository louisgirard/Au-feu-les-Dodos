using UnityEngine;

public class GlobalSaveSystem : MonoBehaviour
{
    private int testCheckpoint = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SavePlayerSystem savePlayer = (SavePlayerSystem)FindObjectOfType(typeof(SavePlayerSystem));
        SaveDodoSystem saveDodo = (SaveDodoSystem)FindObjectOfType(typeof(SaveDodoSystem));

        PlayerEnjoyment playerEnjoyment = (PlayerEnjoyment)FindObjectOfType(typeof(PlayerEnjoyment));
        DodoHealth dodoHealth = (DodoHealth)FindObjectOfType(typeof(DodoHealth));
        if (collision.CompareTag("Player"))
        {
            savePlayer.SavePlayer();
            saveDodo.SaveDodo();
            if (testCheckpoint == 0)
            {
                playerEnjoyment.currentEnjoyment = playerEnjoyment.maxEnjoyment;
                dodoHealth.health = dodoHealth.maxHealth;
            }
            testCheckpoint++;
        }
    }

    private void Update()
    {
        SavePlayerSystem savePlayer = (SavePlayerSystem)FindObjectOfType(typeof(SavePlayerSystem));
        SaveDodoSystem saveDodo = (SaveDodoSystem)FindObjectOfType(typeof(SaveDodoSystem));

        PlayerEnjoyment playerEnjoyment = (PlayerEnjoyment)FindObjectOfType(typeof(PlayerEnjoyment));
        DodoHealth dodoHealth = (DodoHealth)FindObjectOfType(typeof(DodoHealth));

        if (playerEnjoyment.currentEnjoyment == 0 || dodoHealth.health == 0)
        {
            savePlayer.LoadPlayer();
            saveDodo.LoadDodo();

            playerEnjoyment.currentEnjoyment = playerEnjoyment.maxEnjoyment;
            dodoHealth.health = dodoHealth.maxHealth;
        }
    }
}
