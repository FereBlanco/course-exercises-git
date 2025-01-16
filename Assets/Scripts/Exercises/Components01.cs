using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Components01 : MonoBehaviour
{
    [SerializeField] GameObject[] gameObjects;
    GameObject[] cubes;
    GameObject[] spheres;

    int timer = 0;
    int timeStep = 30;
    int counterCubes = 0;
    int counterSpheres = 0;

    private void Awake()
    {
        cubes = GameObject.FindGameObjectsWithTag("Cube");
        spheres = GameObject.FindGameObjectsWithTag("Sphere");

        // DeactivateAll(cubes);
        // DeactivateAll(spheres);

        // ShowFirstAndLast(gameObjects);
        // ShowFirstAndLast(cubes);
        // ShowFirstAndLast(spheres);
    }

    void Update()
    {
        timer++;

        if (timer > timeStep)
        {
            timer = 0;

            DeactivateAll(cubes);
            ActivateGameObject(cubes, counterCubes);
            counterCubes++;
            if (counterCubes == cubes.Length) counterCubes = 0;

            DeactivateAll(spheres);
            ActivateGameObject(spheres, counterSpheres);
            counterSpheres++;
            if (counterSpheres == spheres.Length) counterSpheres = 0;
        }
        
    }

    private void ShowFirstAndLast(GameObject[] array)
    {
        if (array == null || array.Length == 0) throw new System.Exception("ERROR: Invalid GameObject array!!!");
        DeactivateAll(array);
        ActivateGameObject(array, 0);
        ActivateGameObject(array, array.Length-1);
    }

    private void DeactivateAll(GameObject[] array)
    {
        foreach (GameObject go in array)
        {
            go.SetActive(false);
        }
    }
    private void ActivateGameObject(GameObject[] array, int position)
    {
        array[position].SetActive(true);
    }

    private void DeactivateGameObject(GameObject[] array, int position)
    {
        array[position].SetActive(false);
    }
}
