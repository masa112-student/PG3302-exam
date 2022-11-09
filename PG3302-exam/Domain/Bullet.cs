namespace Domain
{
    public class Bullet : IHittable
    {
        private Sprite activeSprite = new Sprite("o");

        public Point Pos {
            get => _pos;
            set {
                _pos = value;
                activeSprite.Pos = _pos;
            }
        }
        public Sprite ActiveSprite {
            get {
                return activeSprite;
            }
            set {
                if (value != null)
                    activeSprite = value;
            }
        }

        private Point _pos;

        private int _moveSpeed;

        public Bullet(Point startPos, int speed) {
            _moveSpeed = speed;

            Pos = new Point(startPos);
        }

        public void Update() {
            Pos += new Point(0, -1 * _moveSpeed);
        }

        public Point GetPos() {
            return Pos;
        }

        public bool Hit(IHittable hittable) {
            Point otherP = hittable.GetPos();
            Dimension otherSize = hittable.GetDimension();
            Dimension size = GetDimension();

            return Pos.X < (otherP.X + otherSize.Width) &&
                Pos.Y < (otherP.Y + otherSize.Height) &&
                (Pos.X + size.Width) > otherP.X &&
                (Pos.Y + size.Height) > otherP.Y;
        }

        public Dimension GetDimension() {
            return ActiveSprite.Size;
        }
    }
}


