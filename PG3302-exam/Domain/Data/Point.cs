namespace Domain.Data
{
    /// <summary>
    /// Represents a point in 2D Space
    /// 
    /// Implementet as a struct partially for permormance reasons. But just as (or maybe more) important are how they are used.
    /// With a class, the code 'a.Point = b.Point' would just copy the reference, while the desired outcome would have been to copy the X and the Y values.
    /// With struct assignment being a value copy, we get this behaviour for free. And don't have to change assignments like the one above to something like 'a.Point = new(b.Point.X, b.Point.Y)'
    /// </summary>
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

        public static Point operator +(Point a, Point b) => new(a.X + b.X, a.Y + b.Y);
        public static Point operator -(Point a, Point b) => new(a.X - b.X, a.Y - b.Y);
        public static Point operator *(Point a, int b) => new(a.X * b, a.Y * b);
        public static Point operator /(Point a, int b) => new(a.X / b, a.Y / b);
        public static bool operator ==(Point a, Point b) => a.Equals(b);
        public static bool operator !=(Point a, Point b) => !a.Equals(b);
    }
}
