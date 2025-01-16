using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ExerciseCanvas03 : MonoBehaviour
{
    [SerializeField] int number1 = 7;
    [SerializeField] int number2 = 14;
    [SerializeField] TMP_Text tMP_Text1;
    [SerializeField] TMP_Text tMP_Text2;
    [SerializeField] TMP_Text tMP_Text3;
    private void Awake() {
        if (tMP_Text1 == null || number1 < 0 || tMP_Text2 == null || number2 < 0) throw new System.Exception("ERROR: invalid data!!!");

        tMP_Text1.text = $"[The first number is {number1}]";
        tMP_Text2.text = $"[The second number is {number2}]";

        isHigherThan();
    }

    private void isHigherThan()
    {
        // trying List and tokens
        char[] separators = {' ', '[', ']'};
        List<string> tokens1 = new List<string>();
        tokens1.AddRange(tMP_Text1.text.Split(separators));
        tokens1.RemoveAll(obj => obj == "");

        // trying arrays
        string[] tokens2 = tMP_Text2.text.Split(separators);

        int number1 = int.Parse(tokens1[tokens1.Count-1]);
        int number2 = int.Parse(tokens2[tokens2.Length-2]);
        tMP_Text3.text = $"[The first number ({number1}) is {((number1 >= number2) ? "higher or equal than" : "lower than")} the second number ({number2})]";
    }
}
