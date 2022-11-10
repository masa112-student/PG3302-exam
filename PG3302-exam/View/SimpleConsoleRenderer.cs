using Domain;

namespace View
{
    public class SimpleConsoleRenderer : IRenderer
    {
        public SimpleConsoleRenderer() {
            Console.CursorVisible = false;
        }
        ~SimpleConsoleRenderer() {
            Console.CursorVisible = true;
        }

        public void DrawString(int x, int y, string s) {
            if (x < Console.BufferWidth && y < Console.BufferHeight) {
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
                    SetColor(sprite.ColorData[i]);
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
                p.X < Console.BufferWidth &&
                p.Y < Console.BufferHeight;
        }

        private void SetColor(Sprite.Color color) {
            switch (color) {
                case Sprite.Color.White:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case Sprite.Color.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Sprite.Color.Black:
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case Sprite.Color.Yellow:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }
        }
    }
}
