using Domain.Enemies.Decorators;
using System;

namespace Domain.Enemies.Factories
{
    public class MoreSpeedEnemyFactory : EnemyFactory
    {
        public override Enemy getEnemy()
        {
            Enemy enemy = new BasicEnemy();
            enemy = new MoreSpeedEnemyDecorator(enemy);
            enemy.ActiveSprite = SpriteConfig.EnemySprite;

            return enemy;
        }
    }
}

