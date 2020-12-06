using UnityEngine;
using UnityEngine.UI;

public class DodoWorldMap : MonoBehaviour
{
    [SerializeField] Sprite[] dodoHeads = null;
    Image dodoHead;

    private void Start()
    {
        dodoHead = GetComponent<Image>();
    }

    void Update()
    {
        dodoHead.sprite = dodoHeads[CrossSceneInformation.dodoSelected];
    }
}
