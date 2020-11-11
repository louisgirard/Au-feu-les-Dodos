using UnityEngine;
using UnityEngine.UI;

public class CircularBar : MonoBehaviour
{
    Image circle;
    float maxFillAmount;

    private void Awake()
    {
        circle = GetComponent<Image>();
    }

    public void SetAmount(float amount)
    {
        circle.fillAmount = amount * maxFillAmount;
    }

    public void SetDegrees(float degrees)
    {
        circle.fillAmount = degrees / 360.0f;
        maxFillAmount = circle.fillAmount;
    }
}
