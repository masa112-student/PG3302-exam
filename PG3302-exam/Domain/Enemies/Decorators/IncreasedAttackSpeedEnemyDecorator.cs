using System.Diagnostics;

using Domain.Core;

namespace Domain.Enemies.Decorators
{
    /// <summary>
    /// Makes enemies fire faster, changes color to green
    /// </summary>
    internal class IncreasedAttackSpeedEnemyDecorator : BaseEnemyDecorator
    {
        private Stopwatch _attackTimer;
        private readonly Random _attackRandom;

        public IncreasedAttackSpeedEnemyDecorator(Enemy enemy) : base(enemy)
        {
            _attackTimer = Stopwatch.StartNew();
            _attackRandom = new();

            ActiveSprite = new(enemy.ActiveSprite);
        }

        public override int Value => base.Value + 15;
        public override bool ShouldAttack
        {
            get
            {
                if (!CanAttack)
                    return false;

                _attackTimer.Restart();
                return _attackRandom.Next(100) > 50;
            }
        }

        public override int AttackSpeedMs => base.AttackSpeedMs / 3;

        public override bool CanAttack => _attackTimer.ElapsedMilliseconds > AttackSpeedMs;
        public override Sprite ActiveSprite
        {
            get => base.ActiveSprite;
            set
            {
                base.ActiveSprite = value;
                Array.Fill(base.ActiveSprite.ColorData, ConsoleColor.Green);
            }
        }

        public override Bullet Attack()
        {
            _attackTimer.Restart();
            Bullet b = base.Attack();

            Array.Fill(b.ActiveSprite.ColorData, ConsoleColor.Green);
            return b;
        }


    }
}
