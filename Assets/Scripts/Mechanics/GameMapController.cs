
namespace Scripts.Mechanics
{
    public class GameMapController
    {
        GameMap _gameMap;

        public GameMapController(GameMap gameMap)
        {
            _gameMap = gameMap;
        }

        public void Flip(Direct direct)
        {
            _gameMap.Flip(direct);
        }
    }
}
