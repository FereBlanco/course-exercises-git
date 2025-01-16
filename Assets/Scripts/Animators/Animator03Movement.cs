using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator03Movement : MonoBehaviour
{
    float _speed = 5f;
    float _speedJump = 1f;
    private Rigidbody2D rb2D;

    private void Awake() {
        rb2D = this.gameObject.GetComponent<Rigidbody2D>();
        if (rb2D == null) throw new System.Exception("ERROR: this gameobject has no Rigidbody2D!!!");
    }
    private void Update() {
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.position += new Vector3(_speed * (-1), 0f, 0f) * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.position += new Vector3(_speed, 0f, 0f) * Time.deltaTime;
            }
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb2D.AddForce(transform.up * _speedJump, ForceMode2D.Impulse);
        }
    }
}
