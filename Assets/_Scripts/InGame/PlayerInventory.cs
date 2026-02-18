using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool hasKey = false;


    public void CollectKey()
    {
        hasKey = true;
        UIManager.Instance.ShowKeyIcon();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
