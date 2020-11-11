using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void UpdateIcon(Sprite icon)
    {
        image.sprite = icon;
    }
}
