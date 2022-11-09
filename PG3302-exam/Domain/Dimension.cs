namespace Domain
{
    public class Dimension
    {
        public Dimension(int width, int height) {
            Width = width;
            Height = height;
        }
        public Dimension() { }

        public int Width { get; set; }
        public int Height { get; set; }
    }
}
