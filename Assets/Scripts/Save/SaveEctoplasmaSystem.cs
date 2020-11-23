using System.IO;
using UnityEngine;

public class SaveEctoplasmaSystem : MonoBehaviour
{
    string path = "Ectoplasma_Save_File.json";
    string jsonString;

    private void Start()
    {
        if(File.Exists(path))
        {
            DeleteEctoplasmaSave();
        }
        SaveEctoplasma();
    }

    public void SaveEctoplasma()
    {
        MyEctoplasma myEctoplasma = new MyEctoplasma
        {
            position = transform.position
        };
        jsonString = JsonUtility.ToJson(myEctoplasma);
        File.WriteAllText(path, jsonString);
        print("Sauvegarde effectuée pour Ectoplasma");
    }

    public void LoadEctoplasma()
    {
        jsonString = File.ReadAllText(path);
        MyEctoplasma myEctoplasma = JsonUtility.FromJson<MyEctoplasma>(jsonString);

        transform.position = myEctoplasma.position;
        print("Chargement du fichier de sauvegarde d'Ectoplasma");
    }  
    
    public void DeleteEctoplasmaSave()
    {
        File.Delete(path);
        print("Suppression du fichier de sauvegarde d'Ectoplasma");
    }
}

public class MyEctoplasma
{
    public Vector3 position;
}
