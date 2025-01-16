using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Layout02 : MonoBehaviour
{
    [SerializeField] Image[] _images;
    [SerializeField] GameObject _layout;

    private void Awake() {
        if (_images == null || _images.Length == 0) throw new System.Exception("ERROR: _images array is null or empty!!!");

        foreach(var img in _images)
        {
            img.transform.SetParent(_layout.transform);
        }
    }
}
