using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recursion01 : MonoBehaviour
{
    private int number = 5;
    private void Awake() {
        CountUp(1);
    }

    private void CountUp(int number)
    {
        Debug.Log($"BEFORE: {number}");
        if (number != this.number) CountUp(number + 1);
        Debug.Log($"AFTER: {number}");
    }
}
