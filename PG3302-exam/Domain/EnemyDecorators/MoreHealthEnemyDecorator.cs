using Domain.Core;
using Domain.Enemies;

namespace Domain.EnemyDecorators
{
    public class MoreHealthEnemyDecorator : BaseEnemyDecorator
    {
        private int health;

        public MoreHealthEnemyDecorator(Enemy moreHealthEnemy) : base(moreHealthEnemy)
        {
            health = moreHealthEnemy.Health + 1;
        }

        public override int Value => base.Value + 100;

        public override int Health { get => health; set => health = value; }
        public override Sprite ActiveSprite
        {
            get => base.ActiveSprite;
            set
            {
                base.ActiveSprite = value;
                Array.Fill(base.ActiveSprite.ColorData, ConsoleColor.Red);
            }
        }

        public override Bullet Attack(){
            Bullet b = base.Attack();
            Array.Fill(b.ActiveSprite.ColorData, ConsoleColor.Red);
            return b;
        }
    }
}

