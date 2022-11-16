using Domain.EnemyDecorators;

namespace Domain.Enemies
{
    public class FastAttackEnemyFactory : EnemyFactory
    {
        public override Enemy getEnemy() {
            Enemy b = new BasicEnemy();
            b = new IncreasedAttackSpeedEnemyDecorator(b);
            return b;
        }
    }
}

