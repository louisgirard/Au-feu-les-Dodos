using UnityEngine;
using UnityEngine.UI;

public class EnjoymentBar : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient;
    public Image fill;

    public void SetMaxEnjoyment(float enjoyment)
    {
        slider.maxValue = enjoyment;
        slider.value = enjoyment;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetEnjoyment(float enjoyment)
    {
        slider.value = enjoyment;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
