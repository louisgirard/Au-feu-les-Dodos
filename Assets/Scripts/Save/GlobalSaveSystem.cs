using UnityEngine;

public class GlobalSaveSystem : MonoBehaviour
{
    private int testCheckpoint = 0;

    SavePlayerSystem savePlayer;
    SaveDodoSystem saveDodo;
    SaveEctoplasmaSystem saveEctoplasma;

    PlayerEnjoyment playerEnjoyment;
    DodoHealth dodoHealth;

    private void Start()
    {
        savePlayer = FindObjectOfType<SavePlayerSystem>();
        saveDodo = FindObjectOfType<SaveDodoSystem>();
        saveEctoplasma = FindObjectOfType<SaveEctoplasmaSystem>();
        playerEnjoyment = FindObjectOfType<PlayerEnjoyment>();
        dodoHealth = FindObjectOfType<DodoHealth>();
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
            LoadSaveData();
        }
    }

    public void LoadSaveData()
    {
        savePlayer.LoadPlayer();
        saveDodo.LoadDodo();
        saveEctoplasma.LoadEctoplasma();
        FindObjectOfType<EctoplasmaStartFight>().ResetBattle();

        playerEnjoyment.currentEnjoyment = playerEnjoyment.maxEnjoyment;
        dodoHealth.Heal(dodoHealth.maxHealth);
    }
}
