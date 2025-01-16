using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.TouchGame
{
    [RequireComponent(typeof(Collider2D))]
    public class Limit : MonoBehaviour
    {
        private void Awake() {
            float newYScale = Camera.main.orthographicSize * 2f * 1.2f;
            transform.localScale = new Vector2(transform.localScale.x, newYScale);


            float newX = Camera.main.orthographicSize * Camera.main.aspect * Mathf.Sign(transform.position.x); // With Mathf.Sign I get the simetry of the GoalArea
            transform.position = new Vector2(newX, 0f);
        }
    }
}
