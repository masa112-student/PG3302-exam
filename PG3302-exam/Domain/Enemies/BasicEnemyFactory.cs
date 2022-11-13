using Domain.EnemyDecorators;

namespace Domain.Enemies
{
    public class BasicEnemyFactory : EnemyFactory
    {
        public override Enemy getEnemy() {
            return new BasicEnemy();
        }
    }
}

