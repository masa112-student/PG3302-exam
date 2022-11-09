using System;
using System.Diagnostics;
namespace Domain
{
    public class Bullet : IHittable
    {
        private Sprite activeSprite;

        public Point Pos { 
            get => _pos; 
            set {
                _pos = value;
                activeSprite.Pos = _pos;
            } }
        public Sprite ActiveSprite {
            get {
                return activeSprite;
            }
            set {
                if (value != null)
                    activeSprite = value;
            }
        }

        private int _yPos;

        private int _startX;

        private System.Timers.Timer _enemyTimer;
        private Point _pos;

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

        private int _moveSpeed;

        public Bullet(int startY, int startX, int speed) {
            _enemyTimer = new System.Timers.Timer();
            _enemyTimer.Elapsed += BulletTimer_Elapsed;
            _enemyTimer.Interval = 1000.0/speed;
            _enemyTimer.Start();


            _moveSpeed = speed;

            //_maxHeight = maxHeight;
            ActiveSprite = new Sprite("o");
            Pos = new Point(startX, startY);
            _startX = startX;

            YPos = startY;
        }

        private void BulletTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e) {
            //Pos += new Point(0, -1);
            YPos -= 1;
        }


        public void Update() {
            Pos += new Point(0, -1*_moveSpeed);
        }

        public void Draw() {
            Console.SetCursorPosition(_startX, YPos);
            Console.Write("o");
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


