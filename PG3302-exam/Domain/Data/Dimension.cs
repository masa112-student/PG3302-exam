namespace Domain.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class Dimension
    {
        public Dimension(int width, int height) {
            Width = width;
            Height = height;
        }
        public Dimension() { }

        public int Width { get; set; }
        public int Height { get; set; }

        public bool IsPointInside(int x, int y) {
            return IsPointInside(new Point(x, y));
        }
        public bool IsPointInside(Point point) {
            return point.X >= 0 &&
            point.Y >= 0 &&
            point.X < Width &&
            point.Y < Height;
        }
    }
}
