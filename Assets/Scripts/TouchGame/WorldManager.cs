using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Scripts.TouchGame
{
    public class WorldManager : MonoBehaviour
    {
        [SerializeField] ScoreManager _scoreManager;
        [SerializeField] Spikes _spikes;
        [SerializeField] UIManager _UIManager;

        [Space(5), Header("Configuration")]
        [SerializeField] Coin[] _coinPrefabs;
        private List<Coin> _coins;
        [SerializeField, Min(1)] int _maxNumberOfCoins = 10;
        [SerializeField, Range(0.1f, 2f)] float _minTimeBetweenCoins = 0.1f;
        [SerializeField, Range(0.5f, 6f)] float _maxTimeBetweenCoins = 0.5f;
        public bool isPlaying = false;

        private void Awake() {
            Assert.IsNotNull(_scoreManager, "ERROR: _scoreManager is empty");
            Assert.IsNotNull(_spikes, "ERROR: _spikes is empty");
            Assert.IsNotNull(_UIManager, "ERROR: _UIManager is empty");
            Assert.IsTrue(_coinPrefabs.Length > 0, "ERROR: olvidaste los Prefabs");
            Assert.IsTrue(_minTimeBetweenCoins < _maxTimeBetweenCoins, "ERROR: _minTimeBetweenCoins musto to be lower than _maxTimeBetweenCoins");
            
            _coins = new List<Coin>();
        }

        private void OnCoinDestroyedCallback(Coin coin)
        {
            coin.OnCoinDestroyed -= OnCoinDestroyedCallback;
            _scoreManager.AddScore(coin.GetScoreValue());
            _coins.Remove(coin);
            coin.Explode();
            if (isPlaying) StartCoroutine(SpawnCoins());
        }

        IEnumerator SpawnCoins()
        {
            yield return new WaitForSeconds(Random.Range(_minTimeBetweenCoins, _maxTimeBetweenCoins));
            if (isPlaying && (_coins.Count < _maxNumberOfCoins))
            {
                SpawnCoin();
                StartCoroutine(SpawnCoins());
            }
        }

        private void SpawnCoin()
        {
            Coin newCoin = Instantiate(_coinPrefabs[Random.Range(0,_coinPrefabs.Length)], transform);
            _coins.Add(newCoin);
            newCoin.OnCoinDestroyed += OnCoinDestroyedCallback;

            float xLimit = Camera.main.orthographicSize * Camera.main.aspect * 0.8f;
            newCoin.transform.position = new Vector2(Random.Range(-xLimit, xLimit), Camera.main.orthographicSize * 1.2f);
        }

        private void OnGameOverCallback(Spikes spikes)
        {
            isPlaying = false;
            _spikes.OnGameOver -= OnGameOverCallback;

            foreach (var coin in _coins)
            {
                coin.Explode();
            }
            _coins.Clear();

            _scoreManager.SetGameOverScore();
            _UIManager.ShowStartButton();
        }

        public void StartGame()
        {
            isPlaying = true;
            _spikes.OnGameOver += OnGameOverCallback;
            _scoreManager.SetStartGameScore();
            StartCoroutine(SpawnCoins());
        }
    }
}
