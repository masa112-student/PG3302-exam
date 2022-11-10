namespace Domain.Enemies
{
    public class BasicEnemy : Enemy
    {
        private Sprite _activeSprite;
        private bool _isDead;

        private BoardDimensions _boardDimensions;
        private Point _pos;
        private int _movementDir = 1;

        public BasicEnemy() : this(new BoardDimensions()) { }
        public BasicEnemy(BoardDimensions boardDimensions) {
            _boardDimensions = boardDimensions;
            ActiveSprite = new Sprite();
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

        public override int Speed() => 1;

        public override Bullet Attack() {
            return new Bullet(new Point(), 0);
        }

        public override void Move(Point direction) {
                Pos += direction * Speed();
        }

        public override void Update() {
            if (IsDead)
                return;

            Dimension dimension = GetDimension();

            if (
                (_movementDir > 0 && Pos.X == _boardDimensions.Width - dimension.Width) ||
                (_movementDir < 0 && Pos.X <= 0)
            ) {
                Move(new Point(0, 1));
                _movementDir *= -1;
            }
            else {
                Move(new Point(_movementDir, 0));
            }
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

