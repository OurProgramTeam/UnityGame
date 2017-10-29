﻿using Scripts.Gameplay.Fields;
using Scripts.Gameplay.Flip;
using Scripts.Gameplay.StateCalculator;
using System;
using UnityEngine;

namespace Scripts.Gameplay
{
    public class GameplayController : MonoBehaviour
    {
        GameMap _gameMap;

        IFlipBehavior _flipBehavior;
        ICurrentStateCalculator _currentStateCalculator;
        IFieldsService _fieldsService;
        IAnimationTimer _animationTimer;

        #region MonoBehavior members
        private void Start()
        {
            _currentStateCalculator = new CurrentStateCalculator();
            _fieldsService = GetComponent<FieldsService>();
            _animationTimer = GetComponent<AnimationTimer>();

            _gameMap = new GameMap()
            {
                Fields = _fieldsService.GetFields()
            };

            _flipBehavior = GetComponent<FlipBehavior>();
            Orientation currentOrientation = _currentStateCalculator.CalculateOrientaion(_gameMap.CurrentFields);
            _flipBehavior.Init(currentOrientation);
        }

        private void Update()
        {
            OnKeyUp();
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
            ) && !_animationTimer.IsOnAnimation;

            if (!canFlip)
            {
                return;
            }

            _flipBehavior.Flip(direct);
            _animationTimer.StartAnimation();

            var targetPosition = _currentStateCalculator.CalculateTargetPosition(
                _gameMap.Fields,
                _gameMap.CurrentFields,
                currentOrientaion,
                direct);
            _gameMap.Flip(targetPosition);
        }
    }
}