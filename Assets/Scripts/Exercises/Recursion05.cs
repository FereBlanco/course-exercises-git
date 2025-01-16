using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class Recursion05 : MonoBehaviour
{
    private void Start() {
        int numCalls = 5;
        float stepTime = 2f;
        Debug.Log("START!");
        StartCoroutine(DelayedCall(1, numCalls, stepTime));
    }

    IEnumerator DelayedCall(int idCall, int numCalls, float stepTime)
    {
        yield return new WaitForSeconds(stepTime);
        if (numCalls > 1) StartCoroutine(DelayedCall(idCall + 1, numCalls-1, stepTime));
        Debug.Log($"{idCall} :: DELAYED CALL!!!");
    }
}
