using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Outro : MonoBehaviour
{
    [SerializeField] PlayableDirector outroAnimation = null;
    [SerializeField] Text outroText = null;

    float fadeTime = 2;

    void Start()
    {
        MouseAspect.ChangeAspect(MouseAspect.Aspect.Mouse);
        outroAnimation.stopped += EndAnimation;
        ChangeAlphaColor(0);
    }

    private void EndAnimation(PlayableDirector director)
    {
        // Fade in text
        StartCoroutine(TextFadeIn());

        // End Game
        Invoke("ResetGame", 9f);
    }

    private void ResetGame()
    {
        // End Game
        CrossSceneInformation.Reset();
        SceneManager.LoadScene(0);
    }

    IEnumerator TextFadeIn()
    {
        float totalTime = 0;
        while(totalTime < fadeTime)
        {
            totalTime += fadeTime / 50;
            ChangeAlphaColor(totalTime / fadeTime);
            yield return new WaitForSeconds(fadeTime / 50);
        }
    }

    private void ChangeAlphaColor(float alpha)
    {
        outroText.color = new Color(outroText.color.r, outroText.color.g, outroText.color.b, alpha);
    }
}
