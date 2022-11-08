using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if(x < Console.BufferWidth && y < Console.BufferHeight) {
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

            spritePos = new Point(sprite.Pos);
            foreach (string line in lines) {
                if (!IsPointInBounds(spritePos))
                    break;

                Console.SetCursorPosition(spritePos.X, spritePos.Y);
                Console.Write(line);
                spritePos.Y++;
            }
        }

        private bool IsPointInBounds(Point p) {
            return p.X >= 0 &&
                p.Y >= 0 &&
                p.X < Console.BufferWidth &&
                p.Y < Console.BufferHeight;
        }
    }
}
