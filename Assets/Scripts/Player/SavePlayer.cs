using System.IO;
using UnityEngine;

public class SavePlayer : MonoBehaviour
{
    string path, jsonString;

    private void Awake()
    {
        path = "Character_Save_File.json";

        if (!File.Exists(path))
        {
            MySuperPompier mySuperPompier = new MySuperPompier
            {
                position = transform.position
            };
            jsonString = JsonUtility.ToJson(mySuperPompier);
            File.WriteAllText(path, jsonString);
        }
        else
        {
            jsonString = File.ReadAllText(path);
            MySuperPompier mySuperPompier = JsonUtility.FromJson<MySuperPompier>(jsonString);

            transform.position = mySuperPompier.position;
            print("Début de partie Pompier");
        }
    }

    private void Update()
    {
        path = "Character_Save_File.json";

        if (Input.GetKeyUp(KeyCode.E))
        {
            MySuperPompier mySuperPompier = new MySuperPompier
            {
                position = transform.position
            };
            jsonString = JsonUtility.ToJson(mySuperPompier);
            File.WriteAllText(path, jsonString);
            print("Sauvegarde effectuée pour le Joueur");
        }
        else if (Input.GetKeyUp(KeyCode.L))
        {
            jsonString = File.ReadAllText(path);
            MySuperPompier mySuperPompier = JsonUtility.FromJson<MySuperPompier>(jsonString);

            transform.position = mySuperPompier.position;
            print("Chargement du fichier de sauvegarde du joueur");
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            File.Delete(path);
            print("Suppression du fichier de sauvegarde du joueur");
        }
    }
}

public class MySuperPompier
{
    public Vector3 position;
}
