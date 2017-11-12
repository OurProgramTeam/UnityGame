using Scripts.Levels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scripts
{
    public class Menu : MonoBehaviour
    {
        private IGameProgress _gameProgress;
        private GameObject _continueButton;
        
        #region MonoBehaviour members

        private void Start()
        {
            _gameProgress = GetComponent<GameProgress>();
            SetContinueButtonState();
        }

        #endregion

        public void NewGame()
        {
            _gameProgress.NewGame();
        }

        public void ContinueGame()
        {
            if (_gameProgress.CanPlay)
            {
                _gameProgress.LoadLevel();
            }
        }

        public void Exit()
        {
            Application.Quit();
        }

        private void SetContinueButtonState()
        {
            _continueButton = GameObject.Find("ContinueGameButton");
            _continueButton.GetComponent<Button>().interactable = false;

            if (_gameProgress.CanPlay)
            {
                _continueButton.GetComponent<Button>().interactable = true;
            }
        }
    }
}
