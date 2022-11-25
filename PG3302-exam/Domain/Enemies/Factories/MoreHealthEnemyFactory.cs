using Domain.Enemies.Decorators;
using System;


namespace Domain.Enemies.Factories
{
    public class MoreHealthEnemyFactory : EnemyFactory
    {
        public override Enemy getEnemy()
        {
            Enemy enemy = new BasicEnemy();
            enemy = new MoreHealthEnemyDecorator(enemy);
            enemy.ActiveSprite = SpriteConfig.EnemySprite;
            return enemy;
        }
    }
}

