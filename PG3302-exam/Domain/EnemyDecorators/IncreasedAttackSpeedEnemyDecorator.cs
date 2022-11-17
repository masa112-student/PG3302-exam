using System.Diagnostics;

using Domain.Core;
using Domain.Enemies;

namespace Domain.EnemyDecorators
{
    internal class IncreasedAttackSpeedEnemyDecorator : BaseEnemyDecorator
    {
        private Stopwatch _attackTimer;
        private const int _attackSpeedMs = 3000;
        private readonly Random _attackRandom;

        private Sprite _sprite;

        public IncreasedAttackSpeedEnemyDecorator(Enemy enemy) : base(enemy) {
            _attackTimer = Stopwatch.StartNew();
            _attackRandom = new();

            ActiveSprite = new(enemy.ActiveSprite);
        }

        public override int Value => base.Value + 15;
        public override bool ShouldAttack {
            get {
                if (!CanAttack)
                    return false;

                _attackTimer.Restart();
                return _attackRandom.Next(100) > 50;
            }
        }
        public override bool CanAttack => _attackTimer.ElapsedMilliseconds > _attackSpeedMs;
        public override Sprite ActiveSprite {
            get => base.ActiveSprite;
            set {
                base.ActiveSprite = value;
                Array.Fill(base.ActiveSprite.ColorData, ConsoleColor.Green);
            }
        }

        public override Bullet Attack() {
            _attackTimer.Restart();
            Bullet b =  base.Attack();

            Array.Fill(b.ActiveSprite.ColorData, ConsoleColor.Green);
            return b;
        }


    }
}
