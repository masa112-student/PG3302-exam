using System;
namespace Domain.Enemies
{
    public class EnemyDamage
    {
        public EnemyDamage()
        {

        }
        public void Damage(Enemy enemy)
        {
            enemy.Health--;
            if (enemy.Health <= 0)
            {
                enemy.Kill();
            }
        }
    }
}

