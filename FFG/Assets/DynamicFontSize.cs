using UnityEngine;
using UnityEngine.UI;

public class DynamicFontSize : MonoBehaviour
{
    public float scaleFactor = 0.05f; // Adjust this value to get the right font size

    void Update()
    {
        foreach (Text text in GetComponentsInChildren<Text>())
        {
            int newFontSize = (int)(Screen.height * scaleFactor);
            text.fontSize = newFontSize;
            Debug.Log("Setting font size to " + newFontSize);
        }
    }
}