using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class WorldMapLauncher : MonoBehaviour
{
    [SerializeField] PlayableDirector[] toLevel = null;
    [SerializeField] WorldMapMenu menu = null;
    [SerializeField] Text levelName = null;

    private void Start()
    {
        MouseAspect.ChangeAspect(MouseAspect.Aspect.Mouse);
        menu.gameObject.SetActive(false);
        LevelName(CrossSceneInformation.nextLevel - 1);
        MoveToNextLevel();
    }

    public void MoveToNextLevel()
    {
        toLevel[CrossSceneInformation.nextLevel - 1].Play();
        toLevel[CrossSceneInformation.nextLevel - 1].stopped += DisplayMenu;
    }

    private void DisplayMenu(PlayableDirector director)
    {
        menu.gameObject.SetActive(true);
        LevelName(CrossSceneInformation.nextLevel);
    }

    private void LevelName(int level)
    {
        switch (level)
        {
            case 1:
                levelName.text = "Plage";
                break;
            case 2:
                levelName.text = "Jungle";
                break;
            case 3:
                levelName.text = "Montagnes";
                break;
            default:
                levelName.text = "";
                break;
        }
    }
}
