using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace Scripts.Pong
{
    [RequireComponent(typeof(AudioSource))]
    
    public class GoalArea : MonoBehaviour
    {
        [SerializeField] TMP_Text _txtGoal;
        AudioSource _audioSource;
        private int _goals;

        private void Awake() {
            Assert.IsNotNull(_txtGoal, $"ERROR: {this.name} has no TMP_Text");

            _audioSource = GetComponent<AudioSource>();
            Assert.IsNotNull(_audioSource.clip, $"ERROR: {this.name} has no audio clip");

            float newYScale = Camera.main.orthographicSize * 2f * 1.1f;
            transform.localScale = new Vector2(transform.localScale.x, newYScale);


            float newX = Camera.main.orthographicSize * Camera.main.aspect * Mathf.Sign(transform.position.x)* 1.1f; // With Mathf.Sign I get the simetry of the GoalArea
            transform.position = new Vector2(newX, 0f);

            _goals = 0;            
            ShowText();
        }
        private void OnTriggerExit2D(Collider2D other) {
            if (other.tag == Constants.BALL_TAG)
            {
                _goals++;
                ShowText();

                _audioSource.Play();

                StartCoroutine(ResetBall(other));
            }
        }

        IEnumerator ResetBall(Collider2D other)
        {
            yield return new WaitForSeconds(Math.Max(_audioSource.clip.length, 1f)); 
            other.GetComponent<Ball>().ResetCall();  // Bad habit, it must be donw with an EVENT
        }

        private void ShowText()
        {
            _txtGoal.text = _goals.ToString("00"); // With "00" number must to has two characters
        }
    }
}
