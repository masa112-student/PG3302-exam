using Domain.Enemies.Decorators;
using System;

namespace Domain.Enemies.Factories
{
    public class BossEnemyFactory : EnemyFactory
    {
        public override Enemy getEnemy()
        {
            Enemy enemy = new BasicEnemy();
            enemy = new MoreSpeedEnemyDecorator(enemy);
            enemy = new MoreHealthEnemyDecorator(enemy);
            enemy = new MoreHealthEnemyDecorator(enemy);
            enemy = new IncreasedAttackSpeedEnemyDecorator(enemy);
            enemy.ActiveSprite = SpriteConfig.BossEnemySprite;

            Array.Fill(enemy.ActiveSprite.ColorData, ConsoleColor.Magenta);
            return enemy;
        }
    }
}

