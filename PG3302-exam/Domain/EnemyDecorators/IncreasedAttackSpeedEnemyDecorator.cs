using Domain.Core;
using Domain.Enemies;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EnemyDecorators
{
    internal class IncreasedAttackSpeedEnemyDecorator : BaseEnemyDecorator
    {
        private Stopwatch _attackTimer;
        private const int _attackSpeedMs = 3000;
        private readonly Random _attackRandom;

        public IncreasedAttackSpeedEnemyDecorator(Enemy enemy) : base(enemy) {
            _attackTimer = Stopwatch.StartNew();
            _attackRandom = new();
        }
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
