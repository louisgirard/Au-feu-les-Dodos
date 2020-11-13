using System.IO;
using UnityEngine;

public class SaveDodo : MonoBehaviour
{
    string path, jsonString;

    private void Start()
    {
        path = "Dodo_Save_File.json";

        if (!File.Exists(path))
        {
            MyDodo myDodo = new MyDodo
            {
                position = transform.position
            };
            jsonString = JsonUtility.ToJson(myDodo);
            File.WriteAllText(path, jsonString);
        }
        else
        {
            jsonString = File.ReadAllText(path);
            MyDodo myDodo = JsonUtility.FromJson<MyDodo>(jsonString);
            
            transform.position = myDodo.position;
            print("Début de partie Dodo");
        }
    }

    private void Update()
    {
        path = "Dodo_Save_File.json";

        if (Input.GetKeyUp(KeyCode.E))
        {
            MyDodo myDodo = new MyDodo
            {
                position = transform.position
            };
            jsonString = JsonUtility.ToJson(myDodo);
            File.WriteAllText(path, jsonString);
            print("Sauvegarde effectuée pour le Dodo");
        }
        else if (Input.GetKeyUp(KeyCode.L))
        {
            jsonString = File.ReadAllText(path);
            MyDodo myDodo = JsonUtility.FromJson<MyDodo>(jsonString);

            transform.position = myDodo.position;
            print("Chargement du fichier de sauvegarde du Dodo");
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            File.Delete(path);
            print("Suppression du fichier de sauvegarde du Dodo");
        }
    }
}

public class MyDodo
{
    public Vector3 position;
}
