using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WorldMapMenu : MonoBehaviour
{
    [SerializeField] GameObject[] dodoHeads = null;
    [SerializeField] Color buttonSelectedColor = default;

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
        dodoHeads[CrossSceneInformation.dodoSelected].GetComponent<Image>().color = Color.white;
        CrossSceneInformation.dodoSelected = dodo;
        dodoHeads[CrossSceneInformation.dodoSelected].GetComponent<Image>().color = buttonSelectedColor;
    }

    public void LaunchNextLevel()
    {
        SceneManager.LoadScene(CrossSceneInformation.nextLevel);
        MouseAspect.ChangeAspect(MouseAspect.Aspect.Default);
        CrossSceneInformation.nextLevel++;
    }
}
