using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Dimension
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Dimension(int width, int height) {
            Width = width;
            Height = height;
        }
        public Dimension() { }
    }
}
