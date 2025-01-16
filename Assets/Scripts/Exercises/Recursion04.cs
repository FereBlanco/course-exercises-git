using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recursion04 : MonoBehaviour
{
    private void Start() {
        int numBase = 2;
        int numPower = 16;

        Power(numBase, numPower);
    }

    private int Power(int numBase, int numPower)
    {
        int recursivePower;
        if (numPower == 0)
        {
            recursivePower = 1;
        }
        else
        {
            recursivePower = Power(numBase, numPower - 1);
            recursivePower *= numBase;
        }
        Debug.Log($"The power of {numBase} to {numPower} is {recursivePower}.");
        return recursivePower;
    }
}
