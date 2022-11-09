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
        public static bool operator ==(Point? a, Point? b) {
            if (a is null)
                return b is null;
            return a.Equals(b);
        }
        public static bool operator !=(Point? a, Point? b) {
            if (a is null)
                return b is not null;
            return !a.Equals(b);
        }

        public override bool Equals(object? obj) {
            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }
            Point p = (Point)obj;
            return X == p.X && Y == p.Y;    
        }
    }
}
