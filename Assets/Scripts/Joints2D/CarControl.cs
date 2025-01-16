using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CarControl : MonoBehaviour
{
    [SerializeField] Rigidbody2D _chasisRigigBody2D;
    [SerializeField] float _speed = 20f;

    private void Awake() {
        if (_chasisRigigBody2D == null) throw new System.Exception("ERROR:_chasisRigigBody2D is empty!!!");
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _chasisRigigBody2D.AddForce(Vector2.right * _speed);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _chasisRigigBody2D.AddForce(Vector2.right * _speed * (-1));
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            _chasisRigigBody2D.AddForce(Vector2.up * _speed * 5);
        }
    }
}
