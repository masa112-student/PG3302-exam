using Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace View
{
    public class Player
    {
        public Point Pos {
            get => pos; set {
                if (value.Y < 0)
                    value.Y = 0;
                pos = value;
            }
        }
        public int SpirteHeight { get; set; }
        public int SpirteWidth { get; set; }

        public Sprite ActiveSprite {
            get {
                activeSprite.Pos = Pos;
                return activeSprite;
            }
            set {
                if (value != null)
                    activeSprite = value;
            }
        }

        public bool CanAttack { get => _attackTimer.ElapsedMilliseconds > _attackDelayMs; }

        private readonly int _maxWidth;

        private int _xPos;

        private Sprite activeSprite;
        private Point pos;
        private Stopwatch _attackTimer = new Stopwatch();
        private readonly int _attackDelayMs = 500;


        public int XPos {
            get => _xPos;
            set {
                if (value <= 0)
                    _xPos = 0;
                else if (value >= _maxWidth - SpirteWidth)
                    _xPos = _maxWidth - SpirteWidth;
                else
                    _xPos = value;
            }
        }

        public Player(int maxWidth) {
            _maxWidth = maxWidth;

            XPos = _maxWidth / 2;

            SpirteHeight = 2;
            SpirteWidth = 2;

            _attackTimer.Start();
        }

        public Bullet Attack() {
            _attackTimer.Restart();
            return new Bullet(Pos.Y - 1, Pos.X + 1, 100);
        }

        public void Draw() {
            Console.SetCursorPosition(XPos, (Console.WindowHeight - 2));
            Console.Write("P");
            Console.Write("P");
            Console.SetCursorPosition(XPos, (Console.WindowHeight - 1));

            Console.Write("P");
            Console.Write("P");
        }
    }
}
