using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enemies
{
    public class BaseEnemy : IEnemy, IHittable
    {
        private Sprite _activeSprite;
        private bool _isDead;

        private BoardDimensions _boardDimensions;
        private Point _pos;
        private int _movementDir = 1;

        public BaseEnemy() : this(new BoardDimensions()) { }
        public BaseEnemy(BoardDimensions boardDimensions)
        {
            _boardDimensions = boardDimensions;
            ActiveSprite = new Sprite();
        }

        public Point Pos {
            get => _pos;
            set {
                _pos = value;
                _activeSprite.Pos = value;
            }
        }
        public Sprite ActiveSprite {
            get => _activeSprite;
            set {
                if (value != null) {
                    _activeSprite = value;
                    _activeSprite.Pos = Pos;
                }
            }
        }
        public bool IsDead {
            get => _isDead;
            set {
                _isDead = value;
                ActiveSprite.Visible = !_isDead;
            }
        }

        public int Speed() => 1;

        public Bullet Attack() {
            return new Bullet(new Point(), 0);
        }

        public void Move() { }
        public void Update() {
            if (IsDead)
                return;

            Dimension dimension = GetDimension();

            if (_movementDir > 0 && Pos.X == _boardDimensions.Width - dimension.Width) {
                Pos += new Point(0, 1);
                _movementDir *= -1;
            }
            else if(_movementDir < 0 && Pos.X <= 0) {
                Pos += new Point(0, 1);
                _movementDir *= -1;
            }
            else {
                Pos += new Point(_movementDir * Speed(), 0);
            }
        }

        public Point GetPos() {
            return Pos;
        }

        public bool Hit(IHittable hittable) {
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

        public Dimension GetDimension() {
            return ActiveSprite.Size;
        }

    }
}

