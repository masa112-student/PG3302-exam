using Domain.EnemyDecorators;

namespace Domain.Enemies
{
    public class BasicEnemyFactory : EnemyFactory
    {
        private Dimension _boardDimensions;

        public BasicEnemyFactory(Dimension boardDimensions) {
            _boardDimensions = boardDimensions;
        }

        public override Enemy getEnemy() {
            return new BasicEnemy(_boardDimensions);
        }
    }
}

