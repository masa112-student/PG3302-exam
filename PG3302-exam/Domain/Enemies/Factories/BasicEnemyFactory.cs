namespace Domain.Enemies.Factories
{
    public class BasicEnemyFactory : EnemyFactory
    {
        public override Enemy getEnemy()
        {
            return new BasicEnemy();
        }
    }
}

