using System.Diagnostics;

using Domain.Data;
using Domain.Core;

namespace Domain.Enemies
{
    public class BasicEnemy : Enemy
    {
        private Sprite _activeSprite;

        private Point _pos;
        private Point _movementDir;

        private bool _isDead;
        private const int _value = 100;

        private Random _attackRandom;
        private Stopwatch _attackTimer;
        private const int _attackDelayMs = 10000;

        public BasicEnemy() {
            _activeSprite = new();
            _movementDir = new(1, 0);
        
            _attackRandom = new();
            _attackTimer = Stopwatch.StartNew();

            Health = 1;
            Speed = 1;
            Mask = IHittable.HitMask.Enemy;
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

        public override bool IsDead { get => _isDead; }
        public override int Speed { get; set; }
        public override int Value { get => _value; }
        public override Point MoveDir { get => _movementDir; set => _movementDir = value; }
        public override Dimension Size { get => ActiveSprite.Size; }
        public override bool ShouldAttack { get {
                if (!CanAttack)
                    return false;
                
                _attackTimer.Restart();
                return _attackRandom.Next(100) > 20;
            } }
        public override bool CanAttack { get => _attackTimer.ElapsedMilliseconds > _attackDelayMs; }
        public override IHittable.HitMask Mask { get; set; }
        public override int Health { get; set; }

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
            if (IsDead)
                return false;

            return CollisionHelpers.AABBHit(this, other);
        }

        public override void Kill() {
            _isDead = true;
            ActiveSprite.Visible = false;
        }
    }
}

