using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Sprite
    {
        public enum Color {
            White,
            Black,
            Red
        }


        private Point? _pos;
        private string _data;

        public string Data {
            get => _data;
            private set {
                _data = value;

                string[] lines = value.Split('\n');

                Size = new(
                    width: lines.First().Length,
                    height: lines.Length
                );
            } 
        }
        public Point? Pos {
            get => _pos;
            set {
                PrevPos = _pos;
                _pos = value;
            }
        }


        public Color[] ColorData { get; set; }

        public Dimension Size { get; private set; }

        public Point? PrevPos { get; private set; }
        public Sprite(string data, Point? pos) {
            Data = data;
            Pos = pos;

            ColorData = new Color[data.Replace("\n", String.Empty).Length];
            Array.Fill(ColorData, Color.White);
        }

        public Sprite(Sprite previous) : this(previous.Data, previous.Pos) { }

        public Sprite(string data = "") : this(data, null) { }

        public static Sprite CreateBlankFromSprite(Sprite s) {
            string[] lines = s.Data.Split('\n');
            int width = lines.First().Length;
            int height = lines.Length;

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < height; i++) {
                for(int j = 0; j< width; j++) {
                    stringBuilder.Append(" ");
                }
                stringBuilder.Append("\n");
            }


            return new Sprite(stringBuilder.ToString(), s.Pos);
        }
    }
}
