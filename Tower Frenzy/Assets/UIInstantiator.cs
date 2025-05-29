using UnityEngine;
using UnityEngine.UI;

public class UIInstantiator : MonoBehaviour
{
    public GameObject uiElementPrefab;  // Assign the UI prefab to this
    public Transform uiParent;          // Assign the Canvas or a specific UI Panel

    public void InstantiateUIElement()
    {
        if (uiElementPrefab != null && uiParent != null)
        {
            Instantiate(uiElementPrefab, uiParent);
        }
        else
        {
            Debug.LogWarning("Missing UI prefab or parent reference.");
        }
    }
}
