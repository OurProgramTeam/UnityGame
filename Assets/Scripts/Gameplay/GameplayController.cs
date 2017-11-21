using Scripts.Gameplay.Animations;
using Scripts.Gameplay.Flip;
using Scripts.Gameplay.StateCalculator;
using Scripts.Levels;
using System.Linq;
using UnityEngine;

namespace Scripts.Gameplay
{
    public class GameplayController : MonoBehaviour
    {
        GameMap _gameMap;

        IMenuService _menuService;
        IFlipBehavior _flipBehavior;
        ICurrentStateCalculator _currentStateCalculator;
        IBlockAnimation _blockAnimation;
        IGameProgress _gameProgress;
        IAnimationObservable _animationObservable;

        #region MonoBehavior members
        private void Start()
        {
            _currentStateCalculator = new CurrentStateCalculator();
            _blockAnimation = GetComponent<IBlockAnimation>();

            _gameMap = GetComponent<GameMap>();

            _flipBehavior = GetComponent<FlipBehavior>();
            Orientation currentOrientation = _currentStateCalculator.CalculateOrientaion(_gameMap.CurrentFields);
            _flipBehavior.Init(currentOrientation);

            _gameProgress = GetComponent<GameProgress>();
            _gameProgress.SetCurrentLevel();

            _menuService = GetComponent<MenuService>();

            _animationObservable = FindObjectsOfType<AnimationObservable>().Single();
        }

        private void Update()
        {
            if (_animationObservable.IsAllEnd && _gameMap.IsWin)
            {
                if (_gameProgress.CanPlay)
                {
                    _gameProgress.SetNextLevel();
                    _gameProgress.LoadLevel();
                }
                else
                {
                    _menuService.GoToMenu();
                }
            }
            else
            {
                OnKeyUp();
            }
        }
        #endregion

        private void OnKeyUp()
        {
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                FlipIfAllow(Direct.Up);
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                FlipIfAllow(Direct.Down);
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                FlipIfAllow(Direct.Left);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                FlipIfAllow(Direct.Right);
            }
        }

        private void FlipIfAllow(Direct direct)
        {
            var currentOrientaion = _currentStateCalculator.CalculateOrientaion(_gameMap.CurrentFields);
            bool canFlip = _currentStateCalculator.CalculateCanFlip(
                _gameMap.Fields,
                _gameMap.CurrentFields,
                currentOrientaion,
                direct
            ) && !_blockAnimation.IsOnAnimation;

            if (!canFlip)
            {
                return;
            }

            _flipBehavior.Flip(direct);
            _blockAnimation.StartAnimation();

            var targetPosition = _currentStateCalculator.CalculateTargetPosition(
                _gameMap.Fields,
                _gameMap.CurrentFields,
                currentOrientaion,
                direct);
            _gameMap.Flip(targetPosition);
        }
    }
}
