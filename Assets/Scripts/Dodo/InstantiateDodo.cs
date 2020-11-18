using UnityEngine;

public class InstantiateDodo : MonoBehaviour
{
    [SerializeField] GameObject[] dodos = null;

    private void Start()
    {
        Instantiate(dodos[CrossSceneInformation.dodoSelected], transform);
    }
}
