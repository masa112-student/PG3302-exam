using Domain.Enemies.Decorators;
using System;

namespace Domain.Enemies.Factories
{
    public class IncreasedAttackSpeedEnemyFactory : EnemyFactory
    {
        public override Enemy getEnemy()
        {
            Enemy enemy = new BasicEnemy();
            enemy = new IncreasedAttackSpeedEnemyDecorator(enemy);
            enemy.ActiveSprite = SpriteConfig.EnemySprite;
            return enemy;
        }
    }
}

