﻿using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<Weapon> myWeapons = new List<Weapon>();
    private int index = 0;

    WeaponUI weaponUI;

    private void Start()
    {
        weaponUI = FindObjectOfType<WeaponUI>();
        if (myWeapons.Count == 0) return;
        myWeapons[index].gameObject.SetActive(true);

        weaponUI.UpdateIcon(myWeapons[index].GetIcon());
    }

    private void Update()
    {
        if (myWeapons.Count == 0) return;
        ProcessKeyInput();
        ProcessScrollWheel();
        weaponUI.UpdateIcon(myWeapons[index].GetIcon());
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
        if(index + 1 < myWeapons.Count)
        {
            myWeapons[index].gameObject.SetActive(false);
            myWeapons[index + 1].gameObject.SetActive(true);
            index++;
        }
        else
        {
            myWeapons[index].gameObject.SetActive(false);
            index = 0;
            myWeapons[index].gameObject.SetActive(true);
        }
    }

    private void PreviousWeapon()
    {
        if (index - 1 >= 0)
        {
            myWeapons[index].gameObject.SetActive(false);
            myWeapons[index - 1].gameObject.SetActive(true);
            index--;
        }
        else
        {
            myWeapons[index].gameObject.SetActive(false);
            index = myWeapons.Count - 1;
            myWeapons[index].gameObject.SetActive(true);
        }
    }

    private void SwitchWeapon(int weapon)
    {
        if (weapon >= myWeapons.Count) return;
        myWeapons[index].gameObject.SetActive(false);
        index = weapon;
        myWeapons[index].gameObject.SetActive(true);
    }

    public void AddWeapon(Weapon weapon)
    {
        myWeapons.Add(weapon);
    }

    public Weapon GetCurrentWeapon()
    {
        return myWeapons[index];
    }
}