using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recursion02 : MonoBehaviour
{
    private void Start() {
        string text = "PATATA";
        ShowText(text, 1);
        Debug.Log("- - -");
        // ShowReverseText(text, text.Length);
    }

    private void ShowText(string text, int index)
    {
        Debug.Log($"NORMAL :: {index} :: {text[index - 1]}");
        if (index < text.Length) ShowText(text, index + 1);
    }
    private void ShowReverseText(string text, int index)
    {
        Debug.Log($"REVERSE :: {index} :: {text[index - 1]}");
        if (index > 1) ShowReverseText(text, index - 1);
    }

    // private void Start() {
    //     Debug.Log("START!");
    // }
    // private void OnEnable() {
    //     Debug.Log("ENABLE!");
    // }
    // private void OnDisable() {
    //     Debug.Log("DISABLE!");
    // }
}
