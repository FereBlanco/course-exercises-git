using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recursion03 : MonoBehaviour
{
    private void Start() {
        int number = 5;
        Debug.Log($"The addiction of all integers smaller than {number} is {Addiction(number)}.");
    }

    private int Addiction(int number)
    {
        int recursiveAddiction = 0;
        if (number != 0) recursiveAddiction =  Addiction(number - 1);
        recursiveAddiction += number;
        return recursiveAddiction;
    }
}
