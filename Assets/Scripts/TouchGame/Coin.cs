using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Scripts.TouchGame
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Coin : MonoBehaviour
    {
        [SerializeField, Min(1), Tooltip("Coin value")] int _scoreValue = 10;
        [SerializeField] GameObject _coinDestructionPrefab;
        private GameObject _coinDestructionObject;
        public event Action<Coin> OnCoinDestroyed;

        private void Awake() {
            Assert.IsNotNull(_coinDestructionPrefab, "ERROR: _coinDestructionPrefab is empty");
        } 

        private void OnMouseDown() {
            OnCoinDestroyed?.Invoke(this);
        }

        public int GetScoreValue()
        {
            return _scoreValue;
        }

        public void Explode()
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            _coinDestructionObject = Instantiate(_coinDestructionPrefab, transform.position, transform.rotation);
            StartCoroutine(Destroy(_coinDestructionPrefab.GetComponent<ParticleSystem>().main.duration));
        }

        IEnumerator Destroy(float destructionTime)
        {
            gameObject.SetActive(false);
            yield return new WaitForSeconds(destructionTime);
            Destroy(_coinDestructionObject.gameObject);
            Destroy(gameObject);
        }
    }
}
