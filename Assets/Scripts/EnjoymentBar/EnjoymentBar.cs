using UnityEngine;
using UnityEngine.UI;

public class EnjoymentBar : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient;
    public Image fill;

    public void SetMaxEnjoyment(int enjoyment)
    {
        slider.maxValue = enjoyment;
        slider.value = enjoyment;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetEnjoyment(int enjoyment)
    {
        slider.value = enjoyment;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
