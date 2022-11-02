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

        public void DrawChar(int x, int y, char c) {
            if(x < Console.BufferWidth && y < Console.BufferHeight) {
               Console.SetCursorPosition(x, y);
               Console.Write(c);
            }
        }

        public void DrawSprite(Sprite sprite) {
            string[] lines = sprite.Data.Split("\n");
            int yPos = sprite.Pos.Y;
            foreach(string line in lines) {
                if (sprite.Pos.X >= Console.BufferWidth || yPos >= Console.BufferHeight) 
                    break;

                Console.SetCursorPosition(sprite.Pos.X, yPos);
                Console.Write(line);
                yPos++;
            }
        }
    }
}
