using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<Weapon> myWeapons = new List<Weapon>();
    private int indice = 0;

    private void Update()
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
        if(indice + 1 < myWeapons.Count)
        {
            myWeapons[indice].gameObject.SetActive(false);
            myWeapons[indice + 1].gameObject.SetActive(true);
            indice++;
        }
    }

    private void PreviousWeapon()
    {
        if (indice - 1 >= 0)
        {
            myWeapons[indice].gameObject.SetActive(false);
            myWeapons[indice - 1].gameObject.SetActive(true);
            indice--;
        }
    }

    public void AddWeapon(Weapon weapon)
    {
        myWeapons.Add(weapon);
    }


}
