using System.Diagnostics;

using Domain.Data;
using Domain.Core;

namespace Domain.Enemies
{
    public class BasicEnemy : Enemy
    {
        private Sprite _activeSprite;

        private Point _pos;

        private const int VALUE = 100;

        private Random _attackRandom;
        private Stopwatch _attackTimer;
        private const int ATTACK_DELAY_MS = 10000;

        public BasicEnemy() {
            _activeSprite = new();
            MoveDir = new(1, 0);
        
            _attackRandom = new();
            _attackTimer = Stopwatch.StartNew();

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
                return _attackRandom.Next(100) > 20;
            } }
        public override bool CanAttack { get => _attackTimer.ElapsedMilliseconds > ATTACK_DELAY_MS; }

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
            IsDead = true;
            ActiveSprite.Visible = false;
        }
    }
}

