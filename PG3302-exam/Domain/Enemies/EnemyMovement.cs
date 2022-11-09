namespace Domain.Enemies
{
    public class EnemyMovement
    {
        private readonly int _maxWidth;
        private readonly int _maxHeight;

        private int _xPos;

        private int _yPos;

        private System.Timers.Timer enemyTimer;
        private int _moveSpeed;

        public int SpriteHeight { get; set; }
        public int SpriteWidth { get; set; }


        public int XPos {
            get => _xPos;
            set {
                if (value < 0)
                    _xPos = 0;
                else if (value >= _boardDimensions.Width)
                    _xPos = _boardDimensions.Width;
                else
                    _xPos = value;
            }
        }

        public int YPos {
            get => _yPos;
            set {
                if (value < 0)
                    _yPos = 0;
                else if (value >= _maxHeight - SpriteHeight)
                    _yPos = _maxHeight - SpriteHeight;
                else _yPos = value;
            }
        }
        private BoardDimensions _boardDimensions;
        public EnemyMovement(int speed) : this(speed, new BoardDimensions()) { }

        public EnemyMovement(int speed, BoardDimensions boardDimensions) {
            enemyTimer = new System.Timers.Timer();
            //enemyTimer.Elapsed += EnemyTimer_Elapsed;
            enemyTimer.Interval = speed;
            enemyTimer.Start();

            XPos = 0;
            YPos = 0;
            _moveSpeed = speed;

            _boardDimensions = boardDimensions;
        }

        public void Update() {
            if (XPos == _boardDimensions.Width - 2) {
                XPos = 0;
                YPos += 1;
            }
            else { XPos += 1 * _moveSpeed; }
        }
    }
}


