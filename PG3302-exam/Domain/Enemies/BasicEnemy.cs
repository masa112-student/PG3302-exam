namespace Domain.Enemies
{
    public class BasicEnemy : Enemy
    {
        private Sprite _activeSprite;
        private bool _isDead;

        private Dimension _boardDimensions;
        private Point _pos;
        private Point _movementDir = new(1, 0);

        public BasicEnemy() : this(new Dimension()) { }
        public BasicEnemy(Dimension boardDimensions) {
            _boardDimensions = boardDimensions;
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

        public override void Kill() {
            _isDead = true;
            ActiveSprite.Visible = false;
        }
    }
}

