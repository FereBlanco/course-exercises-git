using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Pong
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Net : MonoBehaviour
    {
        private void Awake() {
            SpriteRenderer _sr = GetComponent<SpriteRenderer>();
            _sr.size = new Vector2(_sr.size.x, Camera.main.orthographicSize * 2f);
        }
    }
}
