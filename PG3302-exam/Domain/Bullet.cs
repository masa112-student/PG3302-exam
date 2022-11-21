using Domain.Data;
using Domain.Core;

namespace Domain
{
    public class Bullet : IHittable, IMovable, IHealth
    {
        private Sprite _activeSprite;
        private Point _pos;

        public Bullet(Point startPos, int speed) {
            _activeSprite = new();

            Health = 1;
            Speed = speed;
            Pos = startPos;
            MoveDir = new Point(0, -1);
        }
        public Point Pos {
            get => _pos;
            set {
                _pos = value;
                _activeSprite.Pos = _pos;
            }
        }
        public Sprite ActiveSprite {
            get {
                return _activeSprite;
            }
            set {
                if (value != null)
                    _activeSprite = value;
            }
        }

        public Dimension Size => ActiveSprite.Size;

        public int Speed { get; set; }
        public Point MoveDir { get; set; }
        public IHittable.HitMask Mask { get; set; }

        public bool IsDestroyed => Health <= 0;

        public int Health { get; set; }

        public void Destroy() {
            ActiveSprite.Visible = false;
            Speed = 0;
        }

        public bool Hit(IHittable other) {
            if (IsDestroyed) 
                return false;

            return CollisionHelpers.AABBHit(this, other);
        }
    }
}


