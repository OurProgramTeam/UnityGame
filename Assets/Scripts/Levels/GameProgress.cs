using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Levels
{
    public class GameProgress : MonoBehaviour, IGameProgress
    {
        private const string PlayerPrefsNameLastLevel = "LastLevel";

        [SerializeField]
        Level _currentLevel;

        #region IGameProgress members

        public bool CanPlay
        {
            get
            {
                return LastPlayingLevel > Level.Start
                    && LastPlayingLevel < Level.End;
            }
        }

        public void NewGame()
        {
            LastPlayingLevel = Level.Level1;
            LoadLevel();
        }

        public void SetNextLevel()
        {
            if (LastPlayingLevel < Level.End)
            {
                Debug.Log(LastPlayingLevel);
                LastPlayingLevel = LastPlayingLevel + 1;
            }
        }

        public void LoadLevel()
        {
            if (!CanPlay)
            {
                var exceptionText = String.Format("Can not play Level {0}", LastPlayingLevelAsString);
                throw new Exception(exceptionText);
            }

            SceneManager.LoadScene(LastPlayingLevelAsString);
        }

        public void SetCurrentLevel()
        {
            LastPlayingLevel = _currentLevel;
        }

        #endregion

        private string LastPlayingLevelAsString
        {
            get
            {
                return LastPlayingLevel.ToString("F");
            }
        }

        private Level LastPlayingLevel
        {
            get
            {
                Level lastLevel;
                if (PlayerPrefs.HasKey(PlayerPrefsNameLastLevel))
                {
                    lastLevel = (Level)PlayerPrefs.GetInt(PlayerPrefsNameLastLevel);
                }
                else
                {
                    PlayerPrefs.SetInt(PlayerPrefsNameLastLevel, (int)Level.Start);
                    lastLevel = Level.Start;
                }
                return lastLevel;
            }
            set
            {
                PlayerPrefs.SetInt(PlayerPrefsNameLastLevel, (int)value);
            }
        }
    }
}