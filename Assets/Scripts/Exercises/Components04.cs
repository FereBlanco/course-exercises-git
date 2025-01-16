using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Components04 : MonoBehaviour
{
    [SerializeField] GameObject[] gameObjects;
    // Start is called before the first frame update
    void Awake()
    {
        if (gameObjects == null || gameObjects.Length == 0) throw new System.Exception("ERROR: Invalid array!!!");
        foreach (var go in gameObjects)
        {
            Rigidbody2D rb2D = go.GetComponent<Rigidbody2D>();
            Debug.Log($"{go.name} {((rb2D != null) ? " HAS ": " has NO ")} Rigibody2D.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
