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
            PlayerPrefs.DeleteAll();
        }

        private void SetContinueButtonState()
        {
            var continueButton = GameObject.Find("ContinueGameButton").GetComponent<Button>();
            continueButton.interactable = false;
            if (_gameProgress.CanPlay)
            {
                continueButton.interactable = true;
            }
        }
    }
}
