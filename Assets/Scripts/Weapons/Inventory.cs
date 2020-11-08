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
            NextWeapon(indice);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            PreviousWeapon(indice);
        }

    }

    private void NextWeapon(int indice)
    {
        if(indice + 1 < myWeapons.Count)
        {
            print(indice);
            myWeapons[indice].gameObject.SetActive(false);
            myWeapons[indice + 1].gameObject.SetActive(true);
            indice++;
        }
    }

    private void PreviousWeapon(int indice)
    {
        if (indice - 1 >= 0)
        {
            print(indice);
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
