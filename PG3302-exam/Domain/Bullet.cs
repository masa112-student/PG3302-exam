using System;
using System.Diagnostics;
namespace Domain
{
    public class Bullet
    {
        private Sprite activeSprite;

        public Point Pos { get => pos; set {
                if (value.Y <= 0)
                    value.Y = 0;
                pos = value;
            } }
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

        private int _yPos;

        private int _startX;

        private System.Timers.Timer enemyTimer;
        private Point pos;

        public int SpirteHeight { get; set; }
        public int SpirteWidth { get; set; }

        public int XPos { get => _startX; }
        public int YPos {
            get => _yPos;
            set {
                if (value < 1)
                    _yPos = 0;
                else
                    _yPos = value;

            }
        }

        public Bullet(int startY, int startX, int speed) {
            enemyTimer = new System.Timers.Timer();
            enemyTimer.Elapsed += BulletTimer_Elapsed;
            enemyTimer.Interval = 1000.0/speed;
            enemyTimer.Start();

            //_maxHeight = maxHeight;
            Pos = new Point(startX, startY);
            _startX = startX;

            YPos = startY;

            ActiveSprite = new Sprite(" o ");
        }

        private void BulletTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e) {
            Pos += new Point(0, -1);
            YPos -= 1;
        }

        public void Draw() {
            Console.SetCursorPosition(_startX, YPos);
            Console.Write("o");
            Trace.WriteLine(YPos);
        }
    }
}


