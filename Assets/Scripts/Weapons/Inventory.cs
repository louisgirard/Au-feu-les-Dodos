using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<Weapon> myWeapons = new List<Weapon>();
    private int currentWeapon = 0;

    WeaponUI weaponUI;

    private void Start()
    {
        weaponUI = FindObjectOfType<WeaponUI>();
    }

    private void Update()
    {
        if (myWeapons.Count == 0) return;
        myWeapons[currentWeapon].gameObject.SetActive(true);
        ProcessKeyInput();
        ProcessScrollWheel();
        weaponUI.Display(myWeapons[currentWeapon]);
    }

    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchWeapon(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SwitchWeapon(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SwitchWeapon(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SwitchWeapon(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SwitchWeapon(6);
        }
    }

    private void ProcessScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            NextWeapon();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            PreviousWeapon();
        }
    }

    private void NextWeapon()
    {
        if(currentWeapon + 1 < myWeapons.Count)
        {
            myWeapons[currentWeapon].gameObject.SetActive(false);
            myWeapons[currentWeapon + 1].gameObject.SetActive(true);
            currentWeapon++;
        }
        else
        {
            myWeapons[currentWeapon].gameObject.SetActive(false);
            currentWeapon = 0;
            myWeapons[currentWeapon].gameObject.SetActive(true);
        }
    }

    private void PreviousWeapon()
    {
        if (currentWeapon - 1 >= 0)
        {
            myWeapons[currentWeapon].gameObject.SetActive(false);
            myWeapons[currentWeapon - 1].gameObject.SetActive(true);
            currentWeapon--;
        }
        else
        {
            myWeapons[currentWeapon].gameObject.SetActive(false);
            currentWeapon = myWeapons.Count - 1;
            myWeapons[currentWeapon].gameObject.SetActive(true);
        }
    }

    private void SwitchWeapon(int weapon)
    {
        if (weapon >= myWeapons.Count) return;
        myWeapons[currentWeapon].gameObject.SetActive(false);
        currentWeapon = weapon;
        myWeapons[currentWeapon].gameObject.SetActive(true);
    }

    public void AddWeapon(Weapon weapon)
    {
        if(!myWeapons.Contains(weapon))
        {
            myWeapons.Add(weapon);
        }
    }
}
