using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ExerciseCanvas02 : MonoBehaviour
{
    [SerializeField] int number1 = 7;
    [SerializeField] int number2 = 14;
    [SerializeField] TMP_Text tMP_Text1;
    [SerializeField] TMP_Text tMP_Text2;
    private void Awake() {
        if (tMP_Text1 == null || number1 < 0 || tMP_Text2 == null || number2 < 0) throw new System.Exception("ERROR: invalid data!!!");

        tMP_Text1.text = $"[The number {number1} is {(isEven(number1) ? "an" : "NOT an")} even number.]";
        tMP_Text1.color = (isEven(number1) ? Color.blue : Color.red);
        tMP_Text2.text = $"[The number {number2} is {(isEven(number2) ? "an" : "NOT an")} even number.]";
        tMP_Text2.color = (isEven(number2) ? Color.blue : Color.red);
    }

    private bool isEven(int number)
    {
        return (number % 2 == 0);
    }
}
