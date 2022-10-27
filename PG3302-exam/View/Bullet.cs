using System;
using System.Diagnostics;
namespace View
{
    public class Bullet
    {
        private readonly int _maxHeight;

        private int _yPos;

        private int _startX;

        private System.Timers.Timer enemyTimer;

        public int SpirteHeight { get; set; }
        public int SpirteWidth { get; set; }

        public int XPos { get => _startX; }
        public int YPos
        {
            get => _yPos;
            set
            {
                if (value <= 0)
                    _yPos = 0;
                else if (value >= _maxHeight - SpirteWidth)
                    _yPos = _maxHeight - SpirteWidth;
                else
                    _yPos = value;
            }
        }

        public Bullet(int maxHeight, int startX, int Speed)
        {

            enemyTimer = new System.Timers.Timer();
            enemyTimer.Elapsed += BulletTimer_Elapsed;
            enemyTimer.Interval = Speed;
            enemyTimer.Start();

            _maxHeight = maxHeight;

            _startX = startX;

            YPos = (Console.WindowHeight - 3);

            SpirteHeight = 1;
            SpirteWidth = 1;

        }

        private void BulletTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            YPos -= 1;
        }

        public void Draw()
        {
            Console.SetCursorPosition(_startX, YPos);
            Console.Write("o");
            Trace.WriteLine(YPos);
        }
    }
}


