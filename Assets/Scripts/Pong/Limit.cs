using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Scripts.Pong
{
    [RequireComponent(typeof(AudioSource))]

    public class Limit : MonoBehaviour
    {
        AudioSource _audioSource;
        
        private void Awake() {
            _audioSource = GetComponent<AudioSource>();
            Assert.IsNotNull(_audioSource.clip, $"ERROR: gameobject {this.name} has no audio clip");

            float newXScale = Camera.main.orthographicSize * Camera.main.aspect * 2f * 1.1f;
            transform.localScale = new Vector2(newXScale, transform.localScale.y);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == Constants.BALL_TAG)
            {
                _audioSource.Play();
            }
        }      
    }
}
