namespace Domain.Enemies
{
    public class EnemyDamage
    {
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

