namespace Domain.Data
{
    public struct Point
    {
        public Point(int x, int y) {
            X = x; Y = y;
        }
        public Point() : this(0, 0) { }

        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object? obj) => obj is Point p && Equals(p);
        public bool Equals(Point p) => X == p.X && Y == p.Y;

        public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode();

        public static Point operator +(Point a, Point b) {
            return new Point(a.X + b.X, a.Y + b.Y);
        }
        public static Point operator -(Point a, Point b) {
            return new Point(a.X - b.X, a.Y - b.Y);
        }
        public static Point operator *(Point a, int b) {
            return new Point(a.X * b, a.Y * b);
        }
        public static bool operator ==(Point a, Point b) {
            return a.Equals(b);
        }
        public static bool operator !=(Point a, Point b) {
            return !a.Equals(b);
        }
    }
}
