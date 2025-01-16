using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Components05 : MonoBehaviour
{
    GameObject[] _gameObjects;
    void Awake()
    {
        if (_gameObjects == null || _gameObjects.Length == 0) throw new System.Exception("ERROR: Invalid array!!!");

        for(int i = 0; i < _gameObjects.Length; i++)
        {
            if (_gameObjects[i] == null) throw new System.Exception("ERROR: There is a position with NO gameobject in it!!!");
            SpriteRenderer sr = _gameObjects[i].GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                _gameObjects[i].SetActive(true);
            }
            else
            {
                // throw new System.Exception("ERROR: No Sprite Renderer!!!");
            }

        }        
    }
}
