using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Scripts.TouchGame
{

    public class UIManager : MonoBehaviour
    {
        [SerializeField] WorldManager _worldManager;
        [SerializeField] TMP_Text _txtScore;
        [SerializeField] TMP_Text _txtHighScore;
        [SerializeField] Button _btPlay;

        private void Awake() {
            Assert.IsNotNull(_worldManager, "ERROR: _worldManager is null");
            Assert.IsNotNull(_txtScore, "ERROR: _txtScore is null");
            Assert.IsNotNull(_txtHighScore, "ERROR: _txtHighScore is null");
            Assert.IsNotNull(_btPlay, "ERROR: _btPLay is null");
        }

        internal void UpdateScore(int _newScore)
        {
            _txtScore.text = $"{UITexts.UI_SCORE}{_newScore.ToString(UITexts.UI_SCORE_NUMBER_DIGITS)}";
        }
        internal void UpdateHighScore(int _newHighScore)
        {
            _txtHighScore.text = $"{UITexts.UI_SCORE}{_newHighScore.ToString(UITexts.UI_SCORE_NUMBER_DIGITS)}";
        }

        internal void ShowStartButton()
        {
            _btPlay.gameObject.SetActive(true);
        }

        internal void HideStartButton()
        {
            _btPlay.gameObject.SetActive(false);
        }

        public void StartGameClick()
        {
            _btPlay.gameObject.SetActive(false);
            _worldManager.StartGame();
        }
    }
}
