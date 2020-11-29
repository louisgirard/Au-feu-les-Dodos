using UnityEngine;

public class GameOverBox : MonoBehaviour
{
    [SerializeField] GameObject enjoymentText = null;
    [SerializeField] GameObject dodoText = null;

    public void ShowBox(bool dodoDead)
    {
        dodoText.SetActive(dodoDead);
        enjoymentText.SetActive(!dodoDead);
    }
}
