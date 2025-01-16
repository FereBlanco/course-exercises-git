using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator02 : MonoBehaviour
{
    [SerializeField] Animator _animator;

    public enum WaterColor {NoColor, Blue, Red};

    private void Awake() {
        if (_animator == null) throw new System.Exception("ERROR: _animator is EMPTY!!!");
    }
    public void Empty()
    {
        // _animator.SetBool("BlueWater", false);
        // _animator.SetBool("RedWater", false);
        _animator.SetTrigger("NoWaterTrigger");
    }
    public void BlueWater()
    {
        // _animator.SetBool("BlueWater", true);
        // _animator.SetBool("RedWater", false);
        _animator.SetTrigger("BlueWaterTrigger");
    }
    public void RedWater()
    {
        // _animator.SetBool("BlueWater", false);
        // _animator.SetBool("RedWater", true);
        _animator.SetTrigger("RedWaterTrigger");
    }

    public void SetWaterColor(WaterColor color)
    {
        Debug.Log((int)color);
        _animator.SetInteger("Color", (int)color);
    }
    public void SetWaterColorInt(int colorId)
    {
        Debug.Log(colorId);
        _animator.SetInteger("Color", colorId);
    }
}