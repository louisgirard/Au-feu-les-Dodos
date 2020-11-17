using UnityEngine;
using UnityEngine.Playables;

public class WorldMapLauncher : MonoBehaviour
{
    [SerializeField] PlayableDirector[] toLevel = null;
    [SerializeField] GameObject menu = null;

    private void Start()
    {
        menu.SetActive(false);
        MoveToNextLevel();
    }

    public void MoveToNextLevel()
    {
        toLevel[CrossSceneInformation.nextLevel - 1].Play();
        toLevel[CrossSceneInformation.nextLevel - 1].stopped += DisplayMenu;
    }

    void DisplayMenu(PlayableDirector director)
    {
        menu.SetActive(true);
    }
}
