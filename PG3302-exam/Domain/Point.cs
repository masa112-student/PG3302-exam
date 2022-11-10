namespace Domain
{
    public class Point
    {
        

        public Point(int x, int y) {
            X = x; Y = y;
        }
        public Point() { }
        public Point(Point prevPos) :this(prevPos.X, prevPos.Y) { }

        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object? obj) {
            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }
            Point p = (Point)obj;
            return X == p.X && Y == p.Y;
        }

        public static Point operator +(Point a, Point b) {
            return new Point(a.X + b.X, a.Y + b.Y);
        }
        public static Point operator -(Point a, Point b) {
            return new Point(a.X - b.X, a.Y - b.Y);
        }
        public static Point operator *(Point a, int b) {
            return new Point(a.X * b, a.Y * b);
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
    }
}
