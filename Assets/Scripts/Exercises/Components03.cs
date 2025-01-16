using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Componente03 : MonoBehaviour
{
    [SerializeField] GameObject[] gameObjects;
    [SerializeField] Rigidbody2D[] rb2D;

    int timer = 0;
    int timeStep = 50;
    int counter = 0;

    private void Awake() {
        if (gameObjects == null || gameObjects.Length == 0) throw new System.Exception("ERROR: array gameObjects is no valid!!!");    
        if (rb2D == null || rb2D.Length == 0) throw new System.Exception("ERROR: array rb2D is no valid!!!");

        for (int i = 0; i < rb2D.Length; i++)
        {
            if (rb2D[i] != null)
            {
                rb2D[i].bodyType = RigidbodyType2D.Static;
                Debug.Log($"Elem number {i} is now Static.");
            }
            else
            {
                Debug.Log($"Elem number {i} is null.");
            }
        }
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > timeStep)
        {
            timer = 0;
            for (int i = 0; i < rb2D.Length; i++)
            {
                if (rb2D[i] != null)
                {
                    rb2D[i].gameObject.SetActive(i == counter);
                }
            }
            counter++;
            if (counter == rb2D.Length) counter = 0;
        }
        timer++;
    }
}
