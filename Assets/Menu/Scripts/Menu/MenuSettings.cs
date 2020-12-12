using UnityEngine;

[CreateAssetMenu(menuName = "MenuSettings")]
public class MenuSettings : ScriptableObject
{

    public float menuFadeTime = .5f;
    public Color sceneChangeFadeColor = Color.black;
    [Header("Leave this at zero to start game in same scene as menu, otherwise set to scene index")]
    public int nextSceneIndex = 0;

    [Header("Add your menu music here")]
    public AudioClip mainMenuMusicLoop;
    [Header("If you want to play new music after Start is pressed, add it here")]
    public AudioClip musicWorldMap;
    [Header("If you want to play new music on Level 1, add it here")]
    public AudioClip musicLevel1;
    [Header("If you want to play new music on Level 2, add it here")]
    public AudioClip musicLevel2;
    [Header("If you want to play new music on Level 3, add it here")]
    public AudioClip musicLevel3;
    [Header("If you want to play new music on Ectoplasma fight, add it here")]
    public AudioClip musicEctoplasmaFight;
    [Header("If you want to play new music when a Rodeur is close, add it here")]
    public AudioClip musicRodeurIsClose;
    [Header("If you want to play new music on the end of the level, add it here")]
    public AudioClip musicEndLevel;
    [Header("If you want to play new music on the game over, add it here")]
    public AudioClip musicGameOver;
    [Header("If you want to play new music on the intro, add it here")]
    public AudioClip musicIntro;
}
