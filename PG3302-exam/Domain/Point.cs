using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Point
    {
        public int X;
        public int Y;

        public Point(int x, int y) {
            X = x; Y = y;   
        }
        public Point() {}

        public Point(Point prevPos) {
            X = prevPos.X;
            Y = prevPos.Y; 
        }

        public static Point operator+(Point a, Point b) {
            return new Point(a.X + b.X, a.Y + b.Y);
        }
        public static Point operator-(Point a, Point b) {
            return new Point(a.X - b.X, a.Y - b.Y);
        }

    }
}
