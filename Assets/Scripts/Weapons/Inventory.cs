using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    readonly List<GameObject> weapons = new List<GameObject>();
    private int currentWeapon = 0;

    WeaponUI weaponUI;

    private void Start()
    {
        weaponUI = FindObjectOfType<WeaponUI>();
        foreach(GameObject weapon in CrossSceneInformation.weaponsInInventory)
        {
            GameObject weaponObject = Instantiate(weapon, transform);
            weaponObject.SetActive(false);
            weapons.Add(weaponObject);
        }
    }

    private void Update()
    {
        if (weapons.Count == 0) return;
        weapons[currentWeapon].SetActive(true);
        ProcessKeyInput();
        ProcessScrollWheel();
        weaponUI.Display(weapons[currentWeapon].GetComponent<Weapon>());
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
    }

    private void ProcessScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f || Input.GetButtonDown("weapon"))
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
        if(currentWeapon + 1 < weapons.Count)
        {
            weapons[currentWeapon].SetActive(false);
            weapons[currentWeapon + 1].SetActive(true);
            currentWeapon++;
        }
        else
        {
            weapons[currentWeapon].SetActive(false);
            currentWeapon = 0;
            weapons[currentWeapon].SetActive(true);
        }
    }

    private void PreviousWeapon()
    {
        if (currentWeapon - 1 >= 0)
        {
            weapons[currentWeapon].SetActive(false);
            weapons[currentWeapon - 1].SetActive(true);
            currentWeapon--;
        }
        else
        {
            weapons[currentWeapon].SetActive(false);
            currentWeapon = weapons.Count - 1;
            weapons[currentWeapon].SetActive(true);
        }
    }

    private void SwitchWeapon(int weapon)
    {
        if (weapon >= weapons.Count) return;
        weapons[currentWeapon].SetActive(false);
        currentWeapon = weapon;
        weapons[currentWeapon].SetActive(true);
    }

    public void AddWeapon(Weapon weapon)
    {
        if(!CrossSceneInformation.weaponsInInventory.Contains(weapon.gameObject))
        {
            CrossSceneInformation.weaponsInInventory.Add(weapon.gameObject);
            GameObject weaponObject = Instantiate(weapon.gameObject, transform);
            weaponObject.SetActive(false);
            weapons.Add(weaponObject);
        }
    }
}
