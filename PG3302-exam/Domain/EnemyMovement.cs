using System;
namespace Domain
{
    public class EnemyMovement
    {
        private readonly int _maxWidth;
        private readonly int _maxHeight;

        private int _xPos;

        private int _yPos;

        private System.Timers.Timer enemyTimer;

        public int SpriteHeight { get; set; }
        public int SpriteWidth { get; set; }

        public int XPos
        {
            get => _xPos;
            set
            {
                if (value <= 0)
                    _xPos = 0;
                else if (value >= _maxWidth - SpriteWidth)
                    _xPos = _maxWidth - SpriteWidth;
                else
                    _xPos = value;
            }
        }

        public int YPos
        {
            get => _yPos;
            set
            {
                if (value <= 0)
                    _yPos = 0;
                else if (value >= _maxHeight - SpriteHeight)
                    _yPos = _maxHeight - SpriteHeight;
                else _yPos = value;
            }
        }

        public EnemyMovement(int speed)
        {
            enemyTimer = new System.Timers.Timer();
            enemyTimer.Elapsed += EnemyTimer_Elapsed;
            enemyTimer.Interval = speed;
            enemyTimer.Start();

            _maxWidth = Console.BufferWidth;

            _maxHeight = Console.BufferHeight;

            XPos = 0;

            YPos = 0;

            SpriteHeight = 1;
            SpriteHeight = 1;
        }

        private void EnemyTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            if (XPos == (Console.WindowWidth - 2))
            {
                XPos = 0;
                YPos += 1;
            }
            else { XPos += 1; }
        }
    }
}


