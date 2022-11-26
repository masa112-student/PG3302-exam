using Domain.Core;

namespace Domain.Enemies.Decorators
{
    /// <summary>
    /// Makes enemies tougher, changes color to red
    /// </summary>
    public class MoreHealthEnemyDecorator : BaseEnemyDecorator
    {
        private int _health;
        private readonly ConsoleColor[] _colors;

        public MoreHealthEnemyDecorator(Enemy moreHealthEnemy) : base(moreHealthEnemy)
        {
            _health = moreHealthEnemy.Health + 1;
            _colors = new ConsoleColor[] {
                ConsoleColor.White,
                ConsoleColor.Red,
            };
        }

        public override int Value => base.Value + 100;

        public override int Health { get => _health; set { 
                _health = value;
                Array.Fill(base.ActiveSprite.ColorData, _colors[Math.Clamp(_health - 1, 0, _colors.Length -1)]);
            }
        }

        public override bool IsDestroyed => _health <= 0;
        public override Sprite ActiveSprite
        {
            get => base.ActiveSprite;
            set
            {
                base.ActiveSprite = value;
                Array.Fill(base.ActiveSprite.ColorData, _colors[Math.Clamp(_health - 1, 0, _colors.Length - 1)]);
            }
        }

        public override Bullet Attack()
        {
            Bullet b = base.Attack();
            Array.Fill(b.ActiveSprite.ColorData, ConsoleColor.Red);
            return b;
        }
    }
}

