using Domain;
using System.Diagnostics;

namespace View
{
    public class Player
    {
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
                if (value != null)
                    _activeSprite = value;
            }
        }

        public bool CanAttack { get => _attackTimer.ElapsedMilliseconds > _attackDelayMs; }

        private Sprite _activeSprite;
        private Point _pos;
        private Stopwatch _attackTimer = new Stopwatch();
        private readonly int _attackDelayMs = 500;

        public Player() {
            _attackTimer.Start();
        }

        public Bullet Attack() {
            _attackTimer.Restart();
            Point startPos = new Point(Pos.X + (ActiveSprite.Size.Width / 2), Pos.Y - 1);
            return new Bullet(startPos, 1);
        }
    }
}
