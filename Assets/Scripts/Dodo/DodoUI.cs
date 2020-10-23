using UnityEngine;
using UnityEngine.UI;

public class DodoUI : MonoBehaviour
{
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
    }

    public void UpdateHealth(float health)
    {
        text.text = health.ToString();
    }
}
