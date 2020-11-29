using UnityEngine;

public class LoadSaveMenu : MonoBehaviour
{
    public void LoadData()
    {
        LoadSystem saveSystem = FindObjectOfType<LoadSystem>();
        if(saveSystem)
            saveSystem.LoadSaveData();
    }
}
