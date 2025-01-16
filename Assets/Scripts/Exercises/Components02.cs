using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Components02 : MonoBehaviour
{
    GameObject[] cubes;
    GameObject[] spheres;
    GameObject[] others;
    GameObject[] gameObjects;

    int timer = 0;
    int timeStep = 30;

    bool showEven = true;

    // Start is called before the first frame update
    void Start()
    {
        cubes = GameObject.FindGameObjectsWithTag("Cube");
        spheres = GameObject.FindGameObjectsWithTag("Sphere");
        others = GameObject.FindGameObjectsWithTag("Other");
        
        // gameObjects = (cubes.Concat(spheres).ToArray()).Concat(others).ToArray();
        gameObjects = cubes.Concat(spheres).ToArray();
    }

    void Update()
    {
        timer++;

        if (timer > timeStep)
        {
            timer = 0;
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].SetActive(showEven == (i % 2 == 0));
            }
            showEven = !showEven;
        }
    }
}
