using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;

namespace Scripts.Pong
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(KeyboardInputAdapter))]

    public class Paddle : MonoBehaviour
    {
        [SerializeField, Range(2f,15f)] float _paddleSpeed = 8f;

        IInput input;

        Rigidbody2D _rb2D;
        float _limitY;
        AudioSource _audioSource;

        private void Awake() {
            _rb2D = GetComponent<Rigidbody2D>();

            _audioSource = GetComponent<AudioSource>();
            Assert.IsNotNull(_audioSource.clip, $"ERROR: gameobject {this.name} has no audio clip");

            _limitY = Camera.main.orthographicSize + transform.localScale.y / 2;

            float newX = Camera.main.orthographicSize * Camera.main.aspect * Mathf.Sign(transform.position.x) * 0.9f; // 10% space from the border
            transform.position = new Vector2(newX, transform.position.y);

            input = GetComponent<KeyboardInputAdapter>();
        }

        private void FixedUpdate() {

            if (input.IsButtonUpPressed() && transform.position.y < _limitY)
            {
                _rb2D.velocity = Vector2.up * _paddleSpeed;
            }
            else
            {
                if (input.IsButtonDownPressed() && transform.position.y > _limitY* (-1f))
                {
                    _rb2D.velocity = Vector2.down * _paddleSpeed;
                }
                else
                {
                    _rb2D.velocity = Vector2.zero;
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == Constants.BALL_TAG)
            {
                _audioSource.Play();

                float bounceAngle = (-1) * (transform.position.y - other.transform.position.y) * Constants.MAX_BOUNCE_ANGLE / transform.localScale.y;
                bounceAngle = (transform.localEulerAngles.y == 0 ? bounceAngle : 180f - bounceAngle);

                other.gameObject.GetComponent<Ball>().ReturnBallNewAngle(bounceAngle);
            }
        }        
    }
}