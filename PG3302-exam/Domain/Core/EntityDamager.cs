namespace Domain.Core
{
    public class EntityDamager
    {
        public void Damage(IHealth enemy)
        {
            enemy.Health--;
            if (enemy.Health <= 0)
            {
                enemy.Destroy();
            }
        }
    }
}

