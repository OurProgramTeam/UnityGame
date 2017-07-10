using Scripts.Mechanics;

namespace Scripts.Blocks
{
    public class BlockController
    {
        Block _block;
        GameMap _gameMap;

        public BlockController(GameMap gameMap, Block block)
        {
            _gameMap = gameMap;
            _block = block;
            _block.CurrentPosition = _gameMap.CurrentPosition;
        }

        public void Flip(Direct direct)
        {
            switch (direct)
            {
                case Direct.Left:
                    _block.FlipLeft();
                    break;
                case Direct.Right:
                    _block.FlipRight();
                    break;
                case Direct.Up:
                    _block.FlipUp();
                    break;
                case Direct.Down:
                    _block.FlipDown();
                    break;
            }
        }
    }
}