using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.TouchGame
{
[RequireComponent(typeof(Collider2D))]
    public class Spikes : MonoBehaviour
    {
        public event Action<Spikes> OnGameOver;

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.tag == Constants.COIN_TAG)
            {
                OnGameOver?.Invoke(this);
            }
        }
    }
}
