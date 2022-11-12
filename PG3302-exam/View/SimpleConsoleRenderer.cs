using Domain;

namespace View
{
    public class SimpleConsoleRenderer : IRenderer
    {
        private int _windowWidth;
        private int _windowHeight;

        public SimpleConsoleRenderer(int windowWidth, int windowHeight) {
            _windowWidth = windowWidth;
            _windowHeight = windowHeight;
         
            Console.CursorVisible = false;
        }

        ~SimpleConsoleRenderer() {
            Console.CursorVisible = true;
        }

        public void DrawString(int x, int y, string s) {
            if (x < _windowWidth && y < _windowHeight) {
                Console.SetCursorPosition(x, y);
                Console.Write(s);
            }
        }

        public void ClearScreen() {
            Console.Clear();
        }

        public void DrawSprite(Sprite sprite) {
            if (sprite.Pos == null)
                return;

            ConsoleColor currentColor = Console.ForegroundColor;

            string[] lines = sprite.Data.Split("\n");

            Point spritePos;
            if (sprite.PrevPos != null) {
                spritePos = new Point(sprite.PrevPos);
                foreach (string line in lines) {
                    spritePos.X = sprite.PrevPos.X;
                    foreach (char _ in line) {
                        if (!IsPointInBounds(spritePos))
                            break;
                        Console.SetCursorPosition(spritePos.X, spritePos.Y);
                        Console.Write(" ");
                        spritePos.X++;
                    }
                    spritePos.Y++;
                }
            }

            if (sprite.Visible) {
                spritePos = new Point(sprite.Pos);
                int i = 0;
                foreach (string line in lines) {
                    if (!IsPointInBounds(spritePos))
                        break;
                    Console.ForegroundColor = sprite.ColorData[i];
                    Console.SetCursorPosition(spritePos.X, spritePos.Y);
                    Console.Write(line);
                    spritePos.Y++;
                    i++;
                }
            }
            Console.ForegroundColor = currentColor;
        }

        private bool IsPointInBounds(Point p) {
            return p.X >= 0 &&
                p.Y >= 0 &&
                p.X < _windowWidth &&
                p.Y < _windowHeight;
        }
    }
}
