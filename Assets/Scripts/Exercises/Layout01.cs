using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Layout01 : MonoBehaviour
{
    [SerializeField] Image _imagePrefab;
    [SerializeField] RectTransform _layout;
    private List<Image> _images;
    private int _counter = 0;
    private void Awake()
    {
        if (_imagePrefab == null) throw new System.Exception("ERROR: Image prefab is empty!!!");
        if (_layout == null) throw new System.Exception("ERROR: Layout object is empty!!!");

        _images = new List<Image>();
        for (int i = 0; i < 3; i++)
        {
            AddPrefab();
        }
    }

    // Update is called once per frame
    public void AddPrefab()
    {
        _counter++;
        var imageCopy = Instantiate(_imagePrefab, _layout);
        imageCopy.color = new Color(Random.Range(0.2f, 1f), Random.Range(0.2f, 1f), Random.Range(0.2f, 1f), 1f);
        imageCopy.name = "Copy" + _counter;
        _images.Add(imageCopy);
    }
    public void SubstractPrefab()
    {
        if (_images.Count > 0)
        {
            var imageDestroy = _images[0];
            Destroy(imageDestroy.gameObject);
            _images.RemoveAt(0);
        }
    }
}
