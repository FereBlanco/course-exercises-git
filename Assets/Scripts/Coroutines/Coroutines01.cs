using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coroutines01 : MonoBehaviour
{
   [SerializeField] float _stepTime1 = 1f;
   [SerializeField] float _stepTime2 = 1f;
   [SerializeField] float _stepTime3 = 1f;
   [SerializeField, Range(1,99)] int _numberToCount = 10;
   [SerializeField] float _stepNumber = 0.1f;
   [SerializeField] TMP_Text _showNumber1;
   [SerializeField] TMP_Text _showNumber2;
   [SerializeField] TMP_Text _showNumber3;


   private void Awake() {
        if (_showNumber1 == null && _showNumber2 == null && _showNumber3 == null) throw new System.Exception("ERROR: _showNumber is empty!!!");

        StartCoroutine(ShowNumber(_showNumber1, _numberToCount, _stepTime1, _stepNumber));
        StartCoroutine(ShowNumber(_showNumber2, _numberToCount, _stepTime2, _stepNumber));
        StartCoroutine(ShowNumber(_showNumber3, _numberToCount, _stepTime3, _stepNumber));
   }

   IEnumerator ShowNumber(TMP_Text showNumber, int numberToCount, float stepTime, float stepNumber)
   {
        for (float f = 1; f <= numberToCount; f += stepNumber)
        {
            float round = Mathf.Round(f * 10f) / 10f;
            string strNumber = round.ToString();
            if ((Mathf.Round(f * 10f)) % 10 == 0) strNumber += ",0";
            showNumber.text = strNumber;
            // yield return null;  // Wait 1 frame
            // yield break; // Ends the coroutine
            yield return new WaitForSeconds(stepTime);
        }
   }
}
