using Domain.EnemyDecorators;

namespace Domain.Enemies
{
    public class FastEnemyFactory : EnemyFactory
    {
        public override Enemy getEnemy() {
            Enemy b = new BasicEnemy();
            b = new MoreSpeedEnemyDecorator(b);
            return b;
        }
    }
}

