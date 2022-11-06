using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Sprite
    {
        private Point? pos;

        public string Data { get; private set; }
        public Point? Pos { get => pos; set {
                PrevPos = Pos;
                pos = value;
            } }
        public Point? PrevPos { get; set; }
        public Sprite(string data, Point? pos) {
            Data = data;
            Pos = pos;
        }
        public Sprite(string data = "") : this(data, null) { }
    }
}
