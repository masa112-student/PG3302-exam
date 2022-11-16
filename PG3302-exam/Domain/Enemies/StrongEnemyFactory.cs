using Domain.EnemyDecorators;

namespace Domain.Enemies
{
    public class StrongEnemyFactory : EnemyFactory
    {
        public override Enemy getEnemy()
        {
            Enemy b = new BasicEnemy();
            b = new MoreHealthEnemyDecorator(b);
            return b;
        }
    }
}

