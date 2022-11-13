namespace Domain
{
    public class Bullet : IHittable, IMovable
    {
        private Sprite _activeSprite = new Sprite("o");
        private Point _pos;
        private int _moveSpeed;
        private bool _isDestroyed;

        public Bullet(Point startPos, int speed) {
            _moveSpeed = speed;

            Pos = new Point(startPos);
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

        public int Speed { get => _moveSpeed; set => _moveSpeed = value; }
        public Point MoveDir { get; set; }

        public bool IsDestroyed => _isDestroyed;
        public void Destroy() {
            ActiveSprite.Visible = false;
            Speed = 0;
            _isDestroyed = true;
        }

        public bool Hit(IHittable other) {
            return Pos.X < (other.Pos.X + other.Size.Width) &&
                Pos.Y < (other.Pos.Y + other.Size.Height) &&
                (Pos.X + Size.Width) > other.Pos.X &&
                (Pos.Y + Size.Height) > other.Pos.Y;
        }

    }
}


