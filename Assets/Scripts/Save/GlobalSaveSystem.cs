using UnityEngine;

public class GlobalSaveSystem : MonoBehaviour
{
    private int testCheckpoint = 0;

    SavePlayerSystem savePlayer;
    SaveDodoSystem saveDodo;

    PlayerEnjoyment playerEnjoyment;
    DodoHealth dodoHealth;

    private void Start()
    {
        savePlayer = FindObjectOfType<SavePlayerSystem>();
        saveDodo = FindObjectOfType<SaveDodoSystem>();
        playerEnjoyment = FindObjectOfType<PlayerEnjoyment>();
        dodoHealth = FindObjectOfType<DodoHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            savePlayer.SavePlayer();
            saveDodo.SaveDodo();
            if (testCheckpoint == 0)
            {
                playerEnjoyment.currentEnjoyment = playerEnjoyment.maxEnjoyment;
                dodoHealth.Heal(dodoHealth.maxHealth);
            }
            testCheckpoint++;
        }
    }

    private void Update()
    {
        if (playerEnjoyment.currentEnjoyment == 0 || dodoHealth.health == 0)
        {
            savePlayer.LoadPlayer();
            saveDodo.LoadDodo();

            playerEnjoyment.currentEnjoyment = playerEnjoyment.maxEnjoyment;
            dodoHealth.Heal(dodoHealth.maxHealth);
        }
    }

    public void LoadSaveData()
    {
        savePlayer.LoadPlayer();
        saveDodo.LoadDodo();

        playerEnjoyment.currentEnjoyment = playerEnjoyment.maxEnjoyment;
        dodoHealth.Heal(dodoHealth.maxHealth);
    }
}
