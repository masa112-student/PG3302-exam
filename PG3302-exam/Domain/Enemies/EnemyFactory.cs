using System;

namespace Domain.Enemies
{
    public class EnemyFactory
    {
        public static IEnemy getEnemy(BaseEnemy enemyType)
        {
            IEnemy? enemy = null;
            BaseEnemy baseEnemy = new BaseEnemy();

            if (enemyType.Equals(baseEnemy))
            {
                enemy = new BaseEnemy();
            }
            else if (enemyType.Equals(baseEnemy))
            {
                enemy = new MoreSpeedEnemyDecorator(baseEnemy);
            }
            return enemy;
        }
    }
}

