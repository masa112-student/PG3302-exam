using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public class Sprite
    {
        public string Data { get; private set; }
        public Point Pos { get; set; }

        public Sprite(string data, Point pos) {
            Data = data;
            Pos = pos;
        }
        public Sprite(string data = ""):this(data, new Point(0,0)) { }
    }
}
