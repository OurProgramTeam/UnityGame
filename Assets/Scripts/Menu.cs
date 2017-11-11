using Scripts.Levels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts
{
    public class Menu : MonoBehaviour
    {
        private IGameProgress _gameProgress;

        #region MonoBehaviour members

        private void Start()
        {
            _gameProgress = GetComponent<GameProgress>();
        }
        
        #endregion

        // TODO переименовать NewGame
        // Меняем кнопку на "Новая игра"
        public void StartGame()
        {
            _gameProgress.NewGame();
        }

        // TODO тут делаем кнопку продолжить игру
        // Создаем кнопку продолжить
        // Потом дизабли ее если не _gameProgress.CanPlay
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
    }
}
