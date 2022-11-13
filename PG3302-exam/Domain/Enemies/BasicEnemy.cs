namespace Domain.Enemies
{
    public class BasicEnemy : Enemy
    {
        private Sprite _activeSprite;

        private Point _pos;
        private Point _movementDir = new(1, 0);

        private int _health;
        private bool _isDead;

        public BasicEnemy() {
            _health = 1;

            ActiveSprite = new Sprite();
            Speed = 1;
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
                    _activeSprite.Pos = Pos;
                }
            }
        }

        public override bool IsDead { get => _isDead; }
        public override int Speed { get; set; }
        public override Point MoveDir { get => _movementDir; set => _movementDir = value; }
        public override Dimension Size { get => ActiveSprite.Size; }

        public override Bullet Attack() {
            return new Bullet(new Point(), 0);
        }

        public override bool Hit(IHittable other) {
            if (IsDead)
                return false;

            return Pos.X < other.Pos.X + other.Size.Width &&
                Pos.Y < other.Pos.Y + other.Size.Height &&
                Pos.X + Size.Width > other.Pos.X &&
                Pos.Y + Size.Height > other.Pos.Y;
        }

        public override void Damage() {
            _health--;
            if(_health <= 0) {
                _isDead = true;
                ActiveSprite.Visible = false;
            }
        }
    }
}

