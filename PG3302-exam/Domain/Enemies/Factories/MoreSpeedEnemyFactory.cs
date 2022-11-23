using Domain.Enemies.Decorators;

namespace Domain.Enemies.Factories
{
    public class MoreSpeedEnemyFactory : EnemyFactory
    {
        public override Enemy getEnemy()
        {
            Enemy b = new BasicEnemy();
            b = new MoreSpeedEnemyDecorator(b);
            return b;
        }
    }
}

