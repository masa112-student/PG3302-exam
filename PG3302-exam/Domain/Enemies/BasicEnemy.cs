using System.Diagnostics;

using Domain.Data;
using Domain.Core;

namespace Domain.Enemies
{
    /// <summary>
    /// Basic enemy class. Containing core logic.
    /// 
    /// This basic version has a movespeed of 1, health of 1, and a 20% chance of attacking every 10 seconds.
    /// 
    /// Attack() spawns a bullet on the lower middle of the sprite, that can hit only the player
    /// Hit() returns false if the enemy is dead, otherwise it outsources hitdetection to CollisionHelpers
    /// 
    /// </summary>
    public class BasicEnemy : Enemy
    {
        private Sprite _activeSprite;

        private Point _pos;

        private const int VALUE = 100;

        private readonly Random _attackRandom;
        private readonly Stopwatch _attackTimer;

        public BasicEnemy() {
            _activeSprite = new();
        
            _attackRandom = new();
            _attackTimer = Stopwatch.StartNew();

            MoveDir = new(1, 0);
            Health = 1;
            Speed = 1;
            Mask = IHittable.HitMask.Enemy;
            Value = VALUE;
        }

        public override Point Pos {
            get => _pos;
            set {
                _pos = value;
                _activeSprite.Pos = value;
            }
        }
        public override Sprite ActiveSprite {
            get => _activeSprite;
            set {
                if (value != null) {
                    _activeSprite = value;
                }
            }
        }

        public override Dimension Size { get => ActiveSprite.Size; }
        public override bool ShouldAttack { get {
                if (!CanAttack)
                    return false;
                
                _attackTimer.Restart();
                return _attackRandom.Next(100) < 20;
            } }
        public override bool CanAttack { get => _attackTimer.ElapsedMilliseconds > AttackSpeedMs; }

        public override bool IsDestroyed => Health <= 0;

        public override int AttackSpeedMs => 10000;

        public override Bullet Attack() {
            Point bulleSpawnPoint = Pos + new Point(Size.Width / 2, Size.Height);
            Bullet b = new Bullet(bulleSpawnPoint, 1);

            b.MoveDir = new(0, 1);
            b.ActiveSprite = SpriteConfig.EnemyBulletSprite;

            // Enemy bullets need to hit the player
            b.Mask = IHittable.HitMask.Player;

            _attackTimer.Restart();
            return b;
        }

        public override bool Hit(IHittable other) {
            if (IsDestroyed)
                return false;

            return CollisionHelpers.AABBHit(this, other);
        }

        public override void Destroy() {
            ActiveSprite.Visible = false;
        }
    }
}

