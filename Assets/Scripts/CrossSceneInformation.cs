using System.Collections.Generic;
using UnityEngine;

public class CrossSceneInformation
{
    public static int nextLevel = 1;
    public static int dodoSelected = 0;
    public static List<GameObject> weaponsInInventory = new List<GameObject>();

    public static void Reset()
    {
        nextLevel = 1;
        dodoSelected = 0;
        weaponsInInventory = new List<GameObject>();
    }
}
