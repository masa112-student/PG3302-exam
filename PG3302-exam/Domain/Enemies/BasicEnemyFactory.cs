using Domain.EnemyDecorators;

namespace Domain.Enemies
{
    public class BasicEnemyFactory : EnemyFactory
    {
        private BoardDimensions _boardDimensions;

        public BasicEnemyFactory(BoardDimensions boardDimensions) {
            _boardDimensions = boardDimensions;
        }

        public override Enemy getEnemy() {
            return new BasicEnemy(_boardDimensions);
        }
    }
}

