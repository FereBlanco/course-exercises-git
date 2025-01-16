using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MainCharacterController : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;

    void Start()
    {
    }

    void Update()
    {
        float translation = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(translation, 0, 0);        
    }
}
