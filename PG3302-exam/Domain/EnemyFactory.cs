using System;
namespace Domain
{
    public class EnemyFactory
    {
        public static IEnemy getEnemy(BaseEnemy enemyType)
        {
            IEnemy? enemy = null;
            BaseEnemy baseEnemy = new BaseEnemy();

            if (enemyType.Equals(baseEnemy)) {
                enemy = new BaseEnemy();
            }
            else if (enemyType.Equals(MoreSpeedEnemyDecorator(baseEnemy));
            {
                enemy = new MoreSpeedEnemyDecorator(baseEnemy);
            }
            return enemy;
        }
    }
}

