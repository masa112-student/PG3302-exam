using Domain.Enemies.Decorators;


namespace Domain.Enemies.Factories
{
    public class MoreHealthEnemyFactory : EnemyFactory
    {
        public override Enemy getEnemy()
        {
            Enemy b = new BasicEnemy();
            b = new MoreHealthEnemyDecorator(b);
            return b;
        }
    }
}

