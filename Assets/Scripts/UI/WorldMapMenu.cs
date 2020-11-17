using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldMapMenu : MonoBehaviour
{
    [SerializeField] GameObject[] dodoHeads = null;

    private void Start()
    {
        for(int i = 0; i < dodoHeads.Length; i++)
        {
            if(i + 1 > CrossSceneInformation.nextLevel)
            {
                dodoHeads[i].SetActive(false);
            }
        }
    }

    public void SetDodoSelected(int dodo)
    {
        CrossSceneInformation.dodoSelected = dodo;
    }

    public void LaunchNextLevel()
    {
        SceneManager.LoadScene(CrossSceneInformation.nextLevel);
        MouseAspect.ChangeAspect(MouseAspect.Aspect.Default);
        CrossSceneInformation.nextLevel++;
    }
}
