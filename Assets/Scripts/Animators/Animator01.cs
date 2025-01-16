using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator01 : MonoBehaviour
{
    [SerializeField] Animator _animator;

    private void Awake() {
        if (_animator == null) throw new System.Exception("ERROR: _animator is EMPTY!!!");
    }
    public void Open()
    {
        _animator.SetBool("Close", false);
        _animator.SetBool("Open", true);
    }

    public void Close()
    {
        _animator.SetBool("Open", false);
        _animator.SetBool("Close", true);
    }
}
