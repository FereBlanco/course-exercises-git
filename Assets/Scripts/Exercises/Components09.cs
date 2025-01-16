using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Components09 : MonoBehaviour
{
    [SerializeField] GameObject[] gameObjects;

    private void Awake() {
        if (gameObjects == null || gameObjects.Length == 0) throw new System.Exception("ERROR: Array with NO GameObjects!!!");

        foreach(var go in gameObjects)
        {
            if (go != null)
            {
                SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
                if (sr != null)
                {
                    Debug.Log(sr.sprite.name);
                    go.SetActive(sr.sprite.name.ToLower().Contains("circle"));
                }
                else
                {
                    // throw new System.Exception("ERROR: Any GameObject HAS NO SpriteRenderer!!!");
                }
            }
            else
            {
                // throw new System.Exception("ERROR: Any array position DOESN'T own any GameObject!!!");
            }
        }
    }
}
