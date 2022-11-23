using Domain.Enemies.Decorators;

namespace Domain.Enemies.Factories
{
    public class IncreasedAttackSpeedEnemyFactory : EnemyFactory
    {
        public override Enemy getEnemy()
        {
            Enemy b = new BasicEnemy();
            b = new IncreasedAttackSpeedEnemyDecorator(b);
            return b;
        }
    }
}

