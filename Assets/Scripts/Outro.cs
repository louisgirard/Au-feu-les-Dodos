using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Outro : MonoBehaviour
{
    [SerializeField] PlayableDirector outroAnimation = null;

    void Start()
    {
        MouseAspect.ChangeAspect(MouseAspect.Aspect.Mouse);
        outroAnimation.stopped += EndAnimation;
    }

    private void EndAnimation(PlayableDirector director)
    {
        ResetGame();
    }

    private void ResetGame()
    {
        // End Game
        CrossSceneInformation.Reset();
        SceneManager.LoadScene(0);
    }
}
