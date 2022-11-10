using Domain.EnemyDecorators;

namespace Domain.Enemies
{
    public class FastEnemyFactory : EnemyFactory
    {
        private BoardDimensions _boardDimensions;

        public FastEnemyFactory(BoardDimensions boardDimensions) {
            _boardDimensions = boardDimensions;
        }

        public override Enemy getEnemy() {
            Enemy b = new BasicEnemy(_boardDimensions);
            b = new MoreSpeedEnemyDecorator(b);
            return b;
        }
    }
}

