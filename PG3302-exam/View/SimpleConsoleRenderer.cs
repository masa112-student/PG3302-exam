using Domain.Core;
using Domain.Data;

namespace View
{
    public class SimpleConsoleRenderer : IRenderer
    {
        private Dimension _windowDimension;

        public SimpleConsoleRenderer(Dimension windowDimension) {
            _windowDimension = windowDimension;
            Console.CursorVisible = false;
        }
        public SimpleConsoleRenderer(int windowWidth, int windowHeight) 
            : this(new Dimension(windowWidth, windowHeight)) { }

      

        ~SimpleConsoleRenderer() {
            Console.CursorVisible = true;
        }

        public void DrawString(int x, int y, string s) {
            if (_windowDimension.IsPointInside(x, y)) {
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
                Point prevPos = (Point)sprite.PrevPos;
                spritePos = prevPos;
                foreach (string line in lines) {
                    spritePos.X = prevPos.X;
                    foreach (char _ in line) {
                        if (!_windowDimension.IsPointInside(spritePos))
                            break;
                        Console.SetCursorPosition(spritePos.X, spritePos.Y);
                        Console.Write(" ");
                        spritePos.X++;
                    }
                    spritePos.Y++;
                }
            }

            if (sprite.Visible && sprite.Pos != null) {
                spritePos = (Point)sprite.Pos;
                int i = 0;
                foreach (string line in lines) {
                    if (!_windowDimension.IsPointInside(spritePos))
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
    }
}
