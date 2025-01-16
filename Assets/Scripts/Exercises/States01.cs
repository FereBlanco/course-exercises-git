using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class States01 : MonoBehaviour
{
    [SerializeField] TMP_Text tMP_Text;

    enum STATE {HOLA, ADIOS};
    private STATE _currentState; // it takes the default value of STATE

    private void Awake() {
        Debug.Log(_currentState);
        tMP_Text.text = _currentState.ToString();
    }

    public void toogleText()
    {
        _currentState = ((_currentState == STATE.HOLA) ? STATE.ADIOS : STATE.HOLA);
        tMP_Text.text = _currentState.ToString();
    }
}
