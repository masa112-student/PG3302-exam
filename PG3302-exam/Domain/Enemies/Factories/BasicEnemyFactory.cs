namespace Domain.Enemies.Factories
{
    public class BasicEnemyFactory : EnemyFactory
    {
        public override Enemy getEnemy()
        {
            Enemy enemy = new BasicEnemy();
            enemy.ActiveSprite = SpriteConfig.EnemySprite;
            return enemy;
        }
    }
}

