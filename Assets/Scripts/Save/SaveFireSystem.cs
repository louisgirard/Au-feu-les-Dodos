using System.IO;
using UnityEngine;

public class SaveFireSystem : MonoBehaviour
{
    string path, jsonString;

    private void Start()
    {
        path = "Fire_Save_File.json";
        if (!File.Exists(path))
        {
            MyFire myFire = new MyFire
            {
                position = transform.position
            };
            jsonString = JsonUtility.ToJson(myFire);
            File.WriteAllText(path, jsonString);
        }
        else
        {
            jsonString = File.ReadAllText(path);
            MyFire myFire = JsonUtility.FromJson<MyFire>(jsonString);

            transform.position = myFire.position;
        }
    }

    private void Update()
    {
        path = "Fire_Save_File.json";

        if (Input.GetKeyUp(KeyCode.L))
        {
            jsonString = File.ReadAllText(path);
            MyFire myFire = JsonUtility.FromJson<MyFire>(jsonString);

            transform.position = myFire.position;
            print("Chargement du fichier de sauvegarde des feux");
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            File.Delete(path);
            print("Suppression du fichier de sauvegarde des feux");
        }
    }
    
    public void SaveFire()
    {
        path = "Fire_Save_File.json";

        MyFire myFire = new MyFire
        {
            position = transform.position
        };
        jsonString = JsonUtility.ToJson(myFire);
        File.WriteAllText(path, jsonString);
        print("Sauvegarde effectuée pour les feux");

    }
}


public class MyFire
{
    public Vector3 position;
}
