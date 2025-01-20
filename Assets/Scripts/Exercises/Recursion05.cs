using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class Recursion05 : MonoBehaviour
{
    [SerializeField] int numCalls = 5;
    [SerializeField] float stepTime = 2f;
    [SerializeField] bool isNested = true;
    private void Awake() {
        Debug.Log($"START! - Time: {Time.time}");
        StartCoroutine(DelayedCall(1, numCalls));
    }

    IEnumerator DelayedCall(int idCall, int numCalls)
    {
        Debug.Log($"{idCall} :: START DELAYED CALL!!! - Time: {Time.time}");
        yield return new WaitForSeconds(stepTime);
        if (numCalls > 1)
        {
            if (isNested)
            {
                // Nested recursive calls are generally not recommended, but can sometimes be useful to achieve a certain behavior.
                yield return StartCoroutine(DelayedCall(idCall + 1, numCalls-1));
            }
            else
            {
                StartCoroutine(DelayedCall(idCall + 1, numCalls-1));
            }
        }
        Debug.Log($"{idCall} :: END (isNested = {isNested}) DELAYED CALL!!! - Time: {Time.time}");
    }
}
