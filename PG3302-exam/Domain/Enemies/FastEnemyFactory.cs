using Domain.EnemyDecorators;

namespace Domain.Enemies
{
    public class FastEnemyFactory : EnemyFactory
    {
        private Dimension _boardDimensions;

        public FastEnemyFactory(Dimension boardDimensions) {
            _boardDimensions = boardDimensions;
        }

        public override Enemy getEnemy() {
            Enemy b = new BasicEnemy(_boardDimensions);
            b = new MoreSpeedEnemyDecorator(b);
            return b;
        }
    }
}

