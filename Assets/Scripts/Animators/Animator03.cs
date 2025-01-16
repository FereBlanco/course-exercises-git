using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEditor;
using UnityEngine;

public class Animator03 : MonoBehaviour
{
    [SerializeField] GameObject[] gameObjects;
    // List<GameObject> gameObjectsToDestroy = new
    private class GameObjectsToDestroy
    {
        private GameObject _go;
        private int _timeToDestroy = 10;
        private int _currentTime;

        public GameObjectsToDestroy(GameObject newGo)
        {
            _go = newGo;
            _currentTime = _timeToDestroy;
        }

        private void DestroyGameObject()
        {
            Destroy(_go);
        }

        public void Countdown()
        {
            if (--_currentTime < 1) DestroyGameObject();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Animal")
        {
            Debug.Log("ANIMAL!");
        }
        else if (other.gameObject.tag == "Plant")
        {
            Debug.Log("PLANT!");
        } 
    }

    private void Awake() {
        if (gameObjects == null || gameObjects.Length == 0) throw new System.Exception("ERROR: gameobjects array is NULL or EMPTY!!!");
        SetMovement(0);
    }

    private void Update() {
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.Keypad0))
            {
                SetMovement(0);
            }
            if (Input.GetKey(KeyCode.Keypad1))
            {
                SetMovement(1);
            }
            if (Input.GetKey(KeyCode.Keypad2))
            {
                SetMovement(2);
            }
            if (Input.GetKey(KeyCode.Keypad3))
            {
                SetMovement(3);
            }
        }
    }    

    private void SetMovement(int numObj)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (gameObjects[i] != null)
            {
                Animator03Movement a03m = gameObjects[i].GetComponent<Animator03Movement>();
                if (a03m != null)
                {
                    a03m.enabled = (i == numObj);
                }
            }
        }
    }
}
