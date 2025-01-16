using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

using Random = UnityEngine.Random;

namespace Scripts.Pong
{
    [RequireComponent(typeof(Rigidbody2D))]

    public class Ball : MonoBehaviour
    {
        private Rigidbody2D _rb2D;
        private float _velocityFactor = 1f;
        private float _velocityIncreaseStep = 0.05f;
        private float _initialBreakTime = 1f;
        private float _direction;

        private float _currentSpeed = 3f;

        private void Awake() {
            _rb2D = GetComponent<Rigidbody2D>();

            _direction = 0f;

            StartCoroutine(InicialCall());
        }

        private void FixedUpdate() {
            if (Input.GetKeyUp(KeyCode.R))
            {
                ResetCall();
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                IncreaseSpeed();
            }
        }

        IEnumerator InicialCall()
        {
            yield return new WaitForSeconds(_initialBreakTime);
            ResetCall();
        }

        internal void ResetCall()
        {
            ResetPosition();
            ResetSpeed();
        }

        private void ResetPosition()
        {
            float newY = Camera.main.orthographicSize * UnityEngine.Random.Range(-0.9f, 0.9f);
            transform.position = new Vector2(0f, newY);
        }
        private void ResetSpeed()
        {
            _velocityFactor = 1f;
            if (_direction == 0)
            {
                _direction = Math.Sign(Random.Range(-1f, 1f));
            }
            else
            {
                _direction = Math.Sign(_rb2D.velocity.x) * -1;
            }
            _currentSpeed = _direction * UnityEngine.Random.Range(7f,10f);     // velocity magnitude
            ReturnBallNewAngle(Random.Range(-Constants.MAX_BOUNCE_ANGLE/2, Constants.MAX_BOUNCE_ANGLE/2));
        }

        public void ReturnBallNewAngle(float bounceAngle)
        {
            _rb2D.velocity = new Vector2(Mathf.Cos(Mathf.Deg2Rad * bounceAngle), Mathf.Sin(Mathf.Deg2Rad * bounceAngle)).normalized * _currentSpeed;
            IncreaseSpeed();
        }

        internal void IncreaseSpeed()
        {
            _velocityFactor += _velocityIncreaseStep;
            _rb2D.velocity *= _velocityFactor;
        }

        public float GetVelocity()
        {
            return _currentSpeed;
        }
    }
}
