using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ExerciseCanvas01 : MonoBehaviour
{
    [SerializeField] int number = 10;
    [SerializeField] TMP_Text tMP_Text;
    private void Awake() {
        if (tMP_Text == null || number < 0) throw new System.Exception("ERROR: invalid data!!!");

        int addiction = 0;
        for (int i = number; i > 0; i--)
        {
            addiction += i;
        }
        // tMP_Text.text = "{" + addiction.ToString() + "}";
        tMP_Text.text = $"[{addiction}]";
    }
}
