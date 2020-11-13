using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    [SerializeField] Image weaponImage = null;
    [SerializeField] Image timerImage = null;

    public void Display(Weapon weapon)
    {
        weaponImage.sprite = weapon.GetIcon();
        timerImage.fillAmount = weapon.GetOverheatingTimerRatio();
    }
}
