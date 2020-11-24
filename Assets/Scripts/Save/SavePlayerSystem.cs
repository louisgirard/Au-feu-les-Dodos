using System.IO;
using UnityEngine;

public class SavePlayerSystem : MonoBehaviour
{
    string path = "Character_Save_File.json"; 
    string jsonString;

    private void Start()
    {
        if (File.Exists(path))
        {
            DeletePlayerSave();
        }
        SavePlayer();
    }

    public void SavePlayer()
    {
        path = "Character_Save_File.json";

        MySuperPompier mySuperPompier = new MySuperPompier
        {
            position = transform.position
        };
        jsonString = JsonUtility.ToJson(mySuperPompier);
        File.WriteAllText(path, jsonString);
        print("Sauvegarde effectuée pour le Joueur");
    }
    
    public void LoadPlayer()
    {
        path = "Character_Save_File.json";

        jsonString = File.ReadAllText(path);
        MySuperPompier mySuperPompier = JsonUtility.FromJson<MySuperPompier>(jsonString);

        transform.position = mySuperPompier.position;
        print("Chargement du fichier de sauvegarde du joueur");
    }

    public void DeletePlayerSave()
    {
        File.Delete(path);
        print("Suppression du fichier de sauvegarde du joueur");
    }
}

public class MySuperPompier
{
    public Vector3 position;
}
