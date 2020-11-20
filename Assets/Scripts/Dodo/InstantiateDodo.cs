using UnityEngine;

public class InstantiateDodo : MonoBehaviour
{
    [SerializeField] GameObject[] dodos = null;

    private void Awake()
    {
        Instantiate(dodos[CrossSceneInformation.dodoSelected], transform);
    }
}
