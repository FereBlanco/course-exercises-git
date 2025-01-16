using TMPro;
using UnityEngine;

public class States03: MonoBehaviour
{
    [SerializeField] TMP_Text txtState;

    enum STATE {WAITING_FOR_CREATION, RUNNING, DONE, DELETED, WAITING_FOR_DELETION};
    enum ACTION {CREATE, CANNOT_CREATE, FAIL, END, CANCEL, DELETE, DELETE_BY_THREAD, RESTART};
    private STATE _currentState;

    private void Awake() {
        _currentState = STATE.WAITING_FOR_CREATION;
        ShowState();
    }

    private void Update() {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.C)) CheckState(ACTION.CREATE);
            if (Input.GetKeyDown(KeyCode.N)) CheckState(ACTION.CANNOT_CREATE);
            if (Input.GetKeyDown(KeyCode.F)) CheckState(ACTION.FAIL);
            if (Input.GetKeyDown(KeyCode.E)) CheckState(ACTION.END);
            if (Input.GetKeyDown(KeyCode.L)) CheckState(ACTION.CANCEL);
            if (Input.GetKeyDown(KeyCode.D)) CheckState(ACTION.DELETE);
            if (Input.GetKeyDown(KeyCode.T)) CheckState(ACTION.DELETE_BY_THREAD);
            if (Input.GetKeyDown(KeyCode.R)) CheckState(ACTION.RESTART);
        }
        // other option: switch with STATES (not ACTIONS), which one is more efficient?
        // CONFIRMED: check STATE first is MORE EFFICIENT!!!
    }

    private void CheckState(ACTION action)
    {
        switch (action)
        {
            case ACTION.CREATE:
                if (_currentState == STATE.WAITING_FOR_CREATION) _currentState = STATE.RUNNING;
                break;
            case ACTION.CANNOT_CREATE:
                if (_currentState == STATE.WAITING_FOR_CREATION) _currentState = STATE.DELETED;
                break;
            case ACTION.FAIL:
                if (_currentState == STATE.RUNNING) _currentState = STATE.DELETED;
                break;
            case ACTION.END:
                if (_currentState == STATE.RUNNING) _currentState = STATE.DONE;
                break;
            case ACTION.CANCEL:
                if (_currentState == STATE.RUNNING) _currentState = STATE.WAITING_FOR_DELETION;
                break;
            case ACTION.DELETE:
                if (_currentState == STATE.DONE) _currentState = STATE.WAITING_FOR_DELETION;
                break;
            case ACTION.DELETE_BY_THREAD:
                if (_currentState == STATE.WAITING_FOR_DELETION) _currentState = STATE.DELETED;
                break;
            case ACTION.RESTART:
                _currentState = STATE.WAITING_FOR_CREATION;
                break;
            default:
                break;
        }
        ShowState();
    }

    private void ShowState()
    {
        txtState.text = _currentState.ToString();
    }
}
