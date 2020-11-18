using System.IO;
using UnityEngine;

public class SaveStumpSystem : MonoBehaviour
{
    string path, jsonString;
    void Start()
    {
        path = "Stump_Save_File.json";

        StumpDestruction stumpDestruction = (StumpDestruction)FindObjectOfType(typeof(StumpDestruction));

        if (!File.Exists(path))
        {
            MyStump myStump = new MyStump
            {
                health = stumpDestruction.health
            };
            jsonString = JsonUtility.ToJson(myStump);
            File.WriteAllText(path, jsonString);
        }
        else
        {
            jsonString = File.ReadAllText(path);
            MyStump myStump = JsonUtility.FromJson<MyStump>(jsonString);

            stumpDestruction.health = myStump.health;
        }
    }

    void Update()
    {
        path = "Stump_Save_File.json";

        StumpDestruction stumpDestruction = (StumpDestruction)FindObjectOfType(typeof(StumpDestruction));

        if (Input.GetKeyUp(KeyCode.L))
        {
            jsonString = File.ReadAllText(path);
            MyStump myStump = JsonUtility.FromJson<MyStump>(jsonString);

            stumpDestruction.health = myStump.health;

            print("Chargement du fichier de sauvergarde des troncs");
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            File.Delete(path);
            print("Suppression du fichier de sauvegarde des troncs");
        }
    }
}

public class MyStump
{
    public float health;
}
