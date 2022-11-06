using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public class SimpleConsoleUserInput : IUserInput
    {
        private ConsoleKey? _keyDown = null;

        private Stopwatch sw;
        private double pollRateMs = 35; // Keboard pollrate in the console averages about 33-36ms

        public SimpleConsoleUserInput() {
            sw = Stopwatch.StartNew();
        }

        public bool IsKeyDown(ConsoleKey key) {
            if (Console.KeyAvailable) {
                _keyDown = Console.ReadKey(true).Key;
                sw.Restart();
            }
            else if (sw.ElapsedMilliseconds > pollRateMs) {
                _keyDown = null;
                sw.Restart();
            }

            return key == _keyDown;
        }
        
        public char ReadInput() {
            return Console.ReadKey(true).KeyChar;
        }
    }
}
