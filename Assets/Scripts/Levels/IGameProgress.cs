using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Levels
{
    public interface IGameProgress
    {
        bool CanPlay { get; }
        void NewGame();
        void LoadLevel();
        void SetCurrentLevel();
        void SetNextLevel();
    }
}