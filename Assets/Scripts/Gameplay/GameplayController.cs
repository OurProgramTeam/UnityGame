using Scripts.Gameplay.Fields;
using Scripts.Gameplay.Flip;
using Scripts.Gameplay.StateCalculator;
using UnityEngine;

namespace Scripts.Gameplay
{
    public class GameplayController : MonoBehaviour
    {
        Transform _block;
        GameMap _gameMap;

        IFlipBehavior _flipBehavior;
        ICurrentStateCalculator _currentStateCalculator;
        IFieldsService _fieldsService;

        #region MonoBehavior members
        private void Start()
        {
            _currentStateCalculator = new CurrentStateCalculator();
            _fieldsService = new FieldsService();

            _block = GetComponent<Transform>();
            _gameMap = new GameMap();
            _gameMap.Fields = _fieldsService.GetFields();

            Orientation currentOrientation = _currentStateCalculator.CalculateOrientaion(_gameMap.CurrentFields);
            _flipBehavior = new FlipBehavior(currentOrientation);
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
            if (_currentStateCalculator.CalculateCanMoveOnDirect(
                _gameMap.Fields,
                _gameMap.CurrentFields,
                currentOrientaion,
                direct))
            {
                _flipBehavior.Flip(_block, direct);

                var positionToMove = _currentStateCalculator.CalculateNextPosition(
                    _gameMap.Fields,
                    _gameMap.CurrentFields,
                    currentOrientaion,
                    direct);
                _gameMap.Flip(positionToMove);
            }
        }
    }
}
