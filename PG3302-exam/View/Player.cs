using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace View
{
    internal class Player
    {
        private readonly int _maxWidth;

        private int _xPos;

        public int SpirteHeight { get; set; }
        public int SpirteWidth { get; set; }

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
