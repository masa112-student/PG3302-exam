namespace Domain.Enemies
{
    public class BasicEnemy : Enemy
    {
        private Sprite _activeSprite;
        private bool _isDead;

        private Dimension _boardDimensions;
        private Point _pos;
        private int _movementDir = 1;

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
        public override bool IsDead {
            get => _isDead;
            set {
                _isDead = value;
                ActiveSprite.Visible = !_isDead;
            }
        }

        public override int Speed { get; set; }
        public override int MovementDir { get => _movementDir; set => _movementDir = value; }

        public override Bullet Attack() {
            return new Bullet(new Point(), 0);
        }

        public override void Move(Point direction) {
        }

        public override void Update() {
            if (IsDead)
                return;

        }

        public override Point GetPos() {
            return Pos;
        }

        public override bool Hit(IHittable hittable) {
            if (IsDead)
                return false;

            Point otherP = hittable.GetPos();
            Dimension otherSize = hittable.GetDimension();
            Dimension size = GetDimension();

            return Pos.X < otherP.X + otherSize.Width &&
                Pos.Y < otherP.Y + otherSize.Height &&
                Pos.X + size.Width > otherP.X &&
                Pos.Y + size.Height > otherP.Y;
        }

        public override Dimension GetDimension() {
            return ActiveSprite.Size;
        }

    }
}

