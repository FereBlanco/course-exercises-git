using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;
using UnityEngine.UI;

public class States02: MonoBehaviour
{
    private int _currentMoney;
    [SerializeField, Min(1)] int totalMoneyRequested = 5000;
    [SerializeField] TMP_Text txtState;
    [SerializeField] TMP_Text txtTotalMoney;
    [SerializeField] TMP_Text txtAlert;
    [SerializeField] TMP_InputField txtMoneyToPay;
    [SerializeField] Button payButton;

    enum STATE {REQUESTED, UNDER_REVIEW, AUTHORIZED, DELIVERED, PAID, CANCELED};
    enum ACTION {PROCESS, ACCEPT, REJECT, DEPOSIT, RESTART};
    private STATE _currentState;

    private void Awake() {
        if (txtState == null || txtTotalMoney == null) throw new Exception("ERROR: any Text Object is NULL");

        _currentState = STATE.REQUESTED;
        _currentMoney = 0;

        ShowState();


    }

    private void Update() {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.P)) CheckState(ACTION.PROCESS);
            if (Input.GetKeyDown(KeyCode.A)) CheckState(ACTION.ACCEPT);
            if (Input.GetKeyDown(KeyCode.R)) CheckState(ACTION.REJECT);
            if (Input.GetKeyDown(KeyCode.D)) CheckState(ACTION.DEPOSIT);
            if (Input.GetKeyDown(KeyCode.T)) CheckState(ACTION.RESTART);
            if (_currentState == STATE.DELIVERED && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))) Deposit();
        }
        // other option: switch with STATES (not ACTIONS), which one is more efficient?
        // CONFIRMED: check STATE first is MORE EFFICIENT!!!
    }

    private void CheckState(ACTION action)
    {
        switch (action)
        {
            case ACTION.RESTART:
                _currentState = STATE.REQUESTED;
                _currentMoney = 0;
                break;
            case ACTION.PROCESS:
                if (_currentState == STATE.REQUESTED) _currentState = STATE.UNDER_REVIEW;
                break;
            case ACTION.ACCEPT:
                if (_currentState == STATE.UNDER_REVIEW) _currentState = STATE.AUTHORIZED;
                break;
            case ACTION.REJECT:
                if (_currentState == STATE.UNDER_REVIEW) _currentState = STATE.CANCELED;
                break;
            case ACTION.DEPOSIT:
                if (_currentState == STATE.AUTHORIZED)
                {
                    _currentState = STATE.DELIVERED;
                    _currentMoney = totalMoneyRequested;
                }
                break;
            default:
                break;
        }
        ShowState();
    }

    private void ShowState()
    {
        txtState.text = _currentState.ToString();
        txtTotalMoney.text = $"{_currentMoney.ToString()}€";
        txtAlert.text = "";
        CheckButtonState();
    }

    private void CheckButtonState()
    {
        payButton.gameObject.SetActive(_currentState == STATE.DELIVERED);
        txtMoneyToPay.gameObject.SetActive(_currentState == STATE.DELIVERED);
    }

    public void Deposit()
    {
        if (int.TryParse(txtMoneyToPay.text, out int moneyToPay))   // note that out int moneyToPay is created on the parent
        {
            if ((moneyToPay >= 0) && (_currentMoney - moneyToPay >= 0))
            {
                _currentMoney -= moneyToPay;
                txtMoneyToPay.text = "0";
                if (_currentMoney <= 0)
                {
                    _currentMoney = 0;
                    _currentState = STATE.PAID;
                }
                ShowState();
            }
            else
            {
                txtAlert.text = $"ERROR: {((moneyToPay < 0) ? "Negative amount of money!!!" : "You are paying more money than you should")}";
            }
        }
    }
}
