using System.Text;

using Domain.Data;

namespace Domain.Core
{
    /// <summary>
    /// Class containing all info relevant to storing and drawing a sprite to the screen
    /// 
    /// Data is a (potentially mulitline) string containing the characters of the sprite. From the characters the size of the sprite is calculated. 
    /// The sprite is assument to be rectangular and the dimensions are calculated based on the nr of lines, and the length of the first line.
    /// 
    /// ColorData contains a color for all (non newline) chars in the string. Allowing vast color customization. 
    /// The choice was made to use the ConsoleColor enum as it contains more than enough colors for what the app requires.
    /// </summary>
    public class Sprite
    {

        private Point? _pos;
        private string _data;

        public Sprite(string data, Point? pos)
        {
            Data = data;
            Pos = pos;

            ColorData = new ConsoleColor[data.Replace("\n", string.Empty).Length];
            Array.Fill(ColorData, ConsoleColor.White);

            Visible = true;
        }
        public Sprite(Sprite previous) : this(previous.Data, previous.Pos) { }
        public Sprite(string data = "") : this(data, null) { }

        public string Data
        {
            get => _data;
            private set
            {
                _data = value;

                string[] lines = value.Split('\n');

                Size = new(
                    width: lines.First().Length,
                    height: lines.Length
                );
            }
        }

        public Point? Pos
        {
            get => _pos;
            set
            {
                PrevPos = _pos;
                _pos = value;
            }
        }

        public bool Visible { get; set; }
        public ConsoleColor[] ColorData { get; set; }
        public Dimension Size { get; private set; }
        public Point? PrevPos { get; private set; }

        public static Sprite CreateBlankFromSprite(Sprite s)
        {
            string[] lines = s.Data.Split('\n');
            int width = lines.First().Length;
            int height = lines.Length;

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < height; i++)
            {
                if (i > 0) {
                    stringBuilder.Append("\n");
                }
                for (int j = 0; j < width; j++)
                {
                    stringBuilder.Append(" ");
                }
            }

            return new Sprite(stringBuilder.ToString(), s.Pos);
        }
    }
}
