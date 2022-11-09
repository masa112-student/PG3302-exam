namespace View
{
    public class Powerup
    {
        private readonly int _maxHeight;

        private int _xPos;

        public int SpirteHeight { get; set; }
        public int SpirteWidth { get; set; }

        public int XPos { get => _xPos; }

        public Powerup(int maxHeight, int xPos) {
            _maxHeight = maxHeight;

            _xPos = xPos;

            SpirteHeight = 2;
            SpirteWidth = 2;

        }

        public void Draw() {
            Console.SetCursorPosition(XPos, (Console.WindowHeight - 2));
            Console.Write("#");
            Console.Write("#");

            Console.SetCursorPosition(XPos, (Console.WindowHeight - 1));
            Console.Write("#");
            Console.Write("#");
        }
    }
}

