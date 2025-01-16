using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Components06 : MonoBehaviour
{
    [SerializeField] GameObject[] _gameObjects;
    void Awake()
    {
        if (_gameObjects == null || _gameObjects.Length == 0) throw new System.Exception("ERROR: Invalid array!!!");

        foreach(var go in _gameObjects)
        {
            if (go == null) throw new System.Exception("ERROR: There is a position with NO gameobject in it!!!");
            Rigidbody rb = go.GetComponent<Rigidbody>();
            if (rb != null)
            {
                go.SetActive(true);
            }
            else
            {
                // throw new System.Exception("ERROR: No Sprite Renderer!!!");
                go.SetActive(false);
            }
        }        
    }
}
