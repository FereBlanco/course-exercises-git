using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;


namespace Scripts.TouchGame
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] UIManager _UIManager;
        int _currentScore = 0;
        int _highScore = 0;

        private void Awake() {
            Assert.IsNotNull(_UIManager, "ERROR: _UIManager is null");
            _highScore = PlayerPrefs.GetInt(Constants.HIGHSCORE, 0); // If value doesn't exist _highScore takes the second value: 0
            ShowScore(); 
        }

        private void ShowScore()
        {
            _UIManager.UpdateScore(_currentScore);
            _UIManager.UpdateHighScore(_highScore);
        }

        public void AddScore(int newScore)
        {
            _currentScore += newScore;
            ShowScore(); 
        }

        public void SetStartGameScore()
        {
            _currentScore = 0;
            ShowScore();
        }
        public void SetGameOverScore()
        {
            if (_currentScore > _highScore)
            {
                _highScore = _currentScore;
                PlayerPrefs.SetInt(Constants.HIGHSCORE, _highScore);
            }
            ShowScore();
        }

    }
}
