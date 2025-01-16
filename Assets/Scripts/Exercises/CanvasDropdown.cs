using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class CanvasDropdown : MonoBehaviour
{
    [SerializeField] Image[] _images;
    [SerializeField] GameObject _layout;

    private int _itemSelected;

    private void Awake() {
        Assert.IsNotNull(_layout, "ERROR: _layout is null!!!");
        Assert.IsNotNull(_images, "ERROR: _images is null!!!");
        if (_images.Length == 0) throw new Exception("ERROR: _images array is empty!!!");
        _itemSelected = 0;
    }

    public void OnChangeValue(Int32 numItem)
    {
        _itemSelected = numItem;
    }

    public void CreateItem()
    {
        if (_itemSelected > 0 && _images[_itemSelected-1] != null)
        {
            Instantiate(_images[_itemSelected-1], _layout.transform);
        }
    }
}
