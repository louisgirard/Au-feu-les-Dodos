using UnityEngine;

public class LoadSaveMenu : MonoBehaviour
{
    public void LoadData()
    {
        GlobalSaveSystem saveSystem = FindObjectOfType<GlobalSaveSystem>();
        if(saveSystem)
            saveSystem.LoadSaveData();
    }
}
