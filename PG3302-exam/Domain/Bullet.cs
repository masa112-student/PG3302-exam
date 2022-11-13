namespace Domain
{
    public class Bullet : IHittable
    {
        private Sprite activeSprite = new Sprite("o");
        private Point _pos;
        private int _moveSpeed;

        public Bullet(Point startPos, int speed) {
            _moveSpeed = speed;

            Pos = new Point(startPos);
        }
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

        public Dimension Size => ActiveSprite.Size;

        public void Update() {
            Pos += new Point(0, -1 * _moveSpeed);
        }


        public bool Hit(IHittable other) {

            return Pos.X < (other.Pos.X + other.Size.Width) &&
                Pos.Y < (other.Pos.Y + other.Size.Height) &&
                (Pos.X + Size.Width) > other.Pos.X &&
                (Pos.Y + Size.Height) > other.Pos.Y;
        }

    }
}


