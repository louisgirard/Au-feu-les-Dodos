﻿using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class SaveDodoSystem : MonoBehaviour
{
    string path = "Dodo_Save_File.json";
    string jsonString;
    private void Start()
    {
        if (File.Exists(path))
        {
            DeleteDodoSave();
        }
        SaveDodo();
    }

    public void SaveDodo()
    {
        MyDodo myDodo = new MyDodo
        {
            position = transform.position
        };
        jsonString = JsonUtility.ToJson(myDodo);
        File.WriteAllText(path, jsonString);
        print("Sauvegarde effectuée pour le Dodo");
    }

    public void LoadDodo()
    {
        jsonString = File.ReadAllText(path);
        MyDodo myDodo = JsonUtility.FromJson<MyDodo>(jsonString);

        transform.position = myDodo.position;
        GetComponent<NavMeshAgent>().Warp(myDodo.position);
        print("Chargement du fichier de sauvegarde du Dodo");
    }  
    
    public void DeleteDodoSave()
    {
        File.Delete(path);
        print("Suppression du fichier de sauvegarde du Dodo");
    }
}

public class MyDodo
{
    public Vector3 position;
}
