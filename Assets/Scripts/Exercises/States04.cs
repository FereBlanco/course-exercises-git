using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;
using UnityEngine.UI;

public class States04: MonoBehaviour
{
    [SerializeField] TMP_Text txt_State;
    [SerializeField] Button bt_Change;

    enum STATE {RED, AMBER, GREEN};
    private STATE _currentState;
    [SerializeField] Image[] lights;
    private bool _blink = true;
    private int _blickCounter = 0;
    private int _blickCounterLimit = 100;

    private void Awake() {
        if (txt_State == null || bt_Change == null) throw new Exception("ERROR: any Text Object is NULL");
        _currentState = STATE.RED;
        ShowState();
    }

    private void Update() {
        if (_currentState == STATE.AMBER)
        {
            _blickCounter++;
            if (_blickCounter > _blickCounterLimit)
            {
                _blink = !_blink;
                _blickCounter = 0;
                ShowState();
            }
        }
    }

    public void Change()
    {
        switch (_currentState)
        {
            case STATE.RED:
                _currentState = STATE.GREEN;
                break;
            case STATE.AMBER:
                _currentState = STATE.RED;
                break;
            case STATE.GREEN:
                _currentState = STATE.AMBER;
                _blink = true;
                _blickCounter = 0;
                break;
        }
        ShowState();
    }

    private void ShowState()
    {
        txt_State.text = _currentState.ToString();
        switch (_currentState)
        {
            case STATE.RED:
                txt_State.color = Color.red;
                break;
            case STATE.AMBER:
                txt_State.color = Color.yellow;
                break;
            case STATE.GREEN:
                txt_State.color = Color.green;
                break;
        }
        ChangeLights();
    }

    private void ChangeLights()
    {
        lights[0].color = ((_currentState == STATE.RED) ? Color.red : Color.black);
        lights[1].color = (((_currentState == STATE.AMBER) && (_blink)) ? Color.yellow : Color.black);
        lights[2].color = ((_currentState == STATE.GREEN) ? Color.green : Color.black);
    }
}
