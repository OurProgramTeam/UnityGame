using UnityEngine;
using Scripts.Mechanics;
using Scripts.Blocks;

namespace Scripts
{
    public class GameplayController : MonoBehaviour
    {
        BlockController _blockController;
        GameMapController _gameMapController;
        GameMap _gameMap;

        #region MonoBehavior members
        private void Start()
        {
            Block block = FindObjectOfType<Block>();

            _gameMap = GetComponent<GameMap>();
            _blockController = new BlockController(_gameMap, block);
            _gameMapController = new GameMapController(_gameMap);
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
            if (_gameMap.AllowedDirects[direct])
            {
                FlipOnAllowedDirect(direct);
            }
        }

        private void FlipOnAllowedDirect(Direct direct)
        {
            _blockController.Flip(direct);
            _gameMapController.Flip(direct);
        }
    }
}
