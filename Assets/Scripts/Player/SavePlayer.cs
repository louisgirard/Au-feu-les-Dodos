using System.IO;
using UnityEngine;

public class SavePlayer : MonoBehaviour
{
    string path, jsonString;

    private void Awake()
    {
        PlayerEnjoyment playerEnjoyment = (PlayerEnjoyment)FindObjectOfType(typeof(PlayerEnjoyment));
        path = "Character_Save_File.json";

        if (!File.Exists(path))
        {
            MySuperPompier mySuperPompier = new MySuperPompier();
            jsonString = JsonUtility.ToJson(mySuperPompier);
            File.WriteAllText(path, jsonString);
        }
        else
        {
            jsonString = File.ReadAllText(path);
            MySuperPompier mySuperPompier = JsonUtility.FromJson<MySuperPompier>(jsonString);

            transform.position = mySuperPompier.position;
        }
    }

    private void Update()
    {
        PlayerEnjoyment playerEnjoyment = (PlayerEnjoyment)FindObjectOfType(typeof(PlayerEnjoyment));
        path = "Character_Save_File.json";

        if (Input.GetKey(KeyCode.S))
        {
            MySuperPompier mySuperPompier = new MySuperPompier
            {
                position = transform.position
            };
            jsonString = JsonUtility.ToJson(mySuperPompier);
            File.WriteAllText(path, jsonString);
            print("Sauvegarde effectuée");
        }
        else if (Input.GetKey(KeyCode.L))
        {
            jsonString = File.ReadAllText(path);
            MySuperPompier mySuperPompier = JsonUtility.FromJson<MySuperPompier>(jsonString);

            transform.position = mySuperPompier.position;
            print("Chargement du fichier de sauvegarde");
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            File.Delete(path);
            print("Suppression fichier");
        }
    }
}

public class MySuperPompier
{
    public Vector3 position;
}
