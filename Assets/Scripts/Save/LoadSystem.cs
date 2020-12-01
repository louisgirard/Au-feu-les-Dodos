using UnityEngine;
using System.Collections;

public class LoadSystem : MonoBehaviour
{
    bool loadingData = false;

    SavePlayerSystem savePlayer;
    SaveDodoSystem saveDodo;
    SaveEctoplasmaSystem saveEctoplasma;

    PlayerEnjoyment playerEnjoyment;
    DodoHealth dodoHealth;

    GameOverBox gameOverBox;

    public MenuSettings menuSettings;
    private PlayMusic playMusic;

    private void Start()
    {
        savePlayer = FindObjectOfType<SavePlayerSystem>();
        saveDodo = FindObjectOfType<SaveDodoSystem>();
        saveEctoplasma = FindObjectOfType<SaveEctoplasmaSystem>();
        playerEnjoyment = FindObjectOfType<PlayerEnjoyment>();
        dodoHealth = FindObjectOfType<DodoHealth>();
        gameOverBox = FindObjectOfType<GameOverBox>();
        gameOverBox.gameObject.SetActive(false);

        playMusic = FindObjectOfType<PlayMusic>();
    }

    private void Update()
    {
        if (playerEnjoyment.IsDead() || dodoHealth.IsDead())
        {
            if (!loadingData)
            {
                StartCoroutine(LoadCoroutine());
            }
        }
    }

    IEnumerator LoadCoroutine()
    {
        loadingData = true;

        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 0;
        gameOverBox.gameObject.SetActive(true);
        gameOverBox.ShowBox(dodoHealth.IsDead());
        yield return new WaitForSecondsRealtime(3f);
        LoadSaveData();
        Time.timeScale = 1;
        gameOverBox.gameObject.SetActive(false);

        loadingData = false;
    }

    public void LoadSaveData()
    {
        savePlayer.LoadPlayer();
        saveDodo.LoadDodo();
        saveEctoplasma.LoadEctoplasma();
        FindObjectOfType<EctoplasmaStartFight>().ResetBattle();

        playerEnjoyment.AddEnjoyment(playerEnjoyment.maxEnjoyment);
        dodoHealth.Heal(dodoHealth.maxHealth);

        StartLevelMusic();
    }

    private void StartLevelMusic()
    {
        playMusic.StopMusic();
        playMusic.PlayLevelMusic();
    }
}
