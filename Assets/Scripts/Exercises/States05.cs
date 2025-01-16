using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;
using UnityEngine.UI;

public class States05: MonoBehaviour
{
    [SerializeField] TMP_Text txt_Lives;
    [SerializeField] Image img_Hearts;
    private float _heartWidth;
    private int _lives;

    enum STATE {LIVE, DEAD, DOUBLE_DEAD, FULL_DEAD};
    private STATE _currentState;

    private void Awake() {
        if (txt_Lives == null || img_Hearts == null) throw new Exception("ERROR: any Text Object is NULL");
        _heartWidth = img_Hearts.rectTransform.sizeDelta.x;
        _lives = 1;
        _currentState = STATE.LIVE;
        ShowState();
    }

    private void Update() {
        if (Input.anyKeyDown)
        {
            if ((Input.GetKeyDown(KeyCode.Plus)) || (Input.GetKeyDown(KeyCode.KeypadPlus)))
            {
                // KeyCode.Plus doesn't work with spanish keyboard!!!
                AddLife();
            }
            if ((Input.GetKeyDown(KeyCode.Minus)) || (Input.GetKeyDown(KeyCode.KeypadMinus)))
            {
                // KeyCode.Minus doesn't work with spanish keyboard!!!
                SubstractLife();
            }
        }
    }

    private void ShowState()
    {
        txt_Lives.text = _currentState.ToString();
        img_Hearts.rectTransform.sizeDelta = new Vector2(_heartWidth * _lives, img_Hearts.rectTransform.sizeDelta.y);
    }

    public void AddLife()
    {
        switch (_currentState)
        {
            case STATE.LIVE:
                if (_lives < 3) _lives++;
                break;
            case STATE.DEAD:
                // No transition
                break;
            case STATE.DOUBLE_DEAD:
                // No transition
                break;
            case STATE.FULL_DEAD:
                // No transition
                break;
        }
        ShowState();
    }

    public void SubstractLife()
    {
        switch (_currentState)
        {
            case STATE.LIVE:
                if (_lives >= 1) _lives--;
                if (_lives == 0) _currentState = STATE.DEAD;
                break;
            case STATE.DEAD:
                _currentState = STATE.DOUBLE_DEAD;
                break;
            case STATE.DOUBLE_DEAD:
                _currentState = STATE.FULL_DEAD;
                break;
            case STATE.FULL_DEAD:
                // No transition
                break;
        }
        ShowState();
    }
}
