using System.Diagnostics;

using Domain.Data;
using Domain.Core;

namespace Domain
{
    public class Player : IMovable, IHittable, IHealth
    {
        private Sprite _activeSprite;
        private Point _pos;
        private Stopwatch _attackTimer;
        private readonly int _attackDelayMs = 250;

        public Player() {
            _activeSprite = new();

            _attackTimer = Stopwatch.StartNew();

            Speed = 1;
            Health = 1;
            MoveDir = new Point(0, 0);
            Mask = IHittable.HitMask.Player;
        }
        public Point Pos {
            get => _pos;
            set {
                if (value.Y < 0)
                    value.Y = 0;
                _pos = value;
                _activeSprite.Pos = _pos;
            }
        }
        public Sprite ActiveSprite {
            get {
                return _activeSprite;
            }
            set {
                if (value != null) {
                    _activeSprite = value;
                }
            }
        }
        public bool CanAttack { get => _attackTimer.ElapsedMilliseconds > _attackDelayMs; }
        public int Speed { get; set; }
        public Point MoveDir { get; set; }
        public Dimension Size => ActiveSprite.Size;

        public IHittable.HitMask Mask { get; set; }

        public bool IsDestroyed => Health <= 0;

        public int Health { get; set; }

        public Bullet Attack() {
            Point startPos = new Point(Pos.X + (ActiveSprite.Size.Width / 2), Pos.Y - 1);
            Bullet b = new Bullet(startPos, 1);
            b.ActiveSprite = SpriteConfig.BulletSprite;

            // The players bullets need to hit enemies
            b.Mask = IHittable.HitMask.Enemy;

            _attackTimer.Restart();
            return b;
        }

        public bool Hit(IHittable other) {
            return CollisionHelpers.AABBHit(this, other);
        }

        public void Destroy() {
            _activeSprite.Visible = false;

        }
    }
}
