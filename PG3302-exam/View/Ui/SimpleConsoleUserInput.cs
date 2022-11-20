using System.Diagnostics;

namespace View.Ui
{
    /// <summary>
    /// Input implementation that's usable on all platforms
    /// </summary>
    public class SimpleConsoleUserInput : IUserInput
    {
        private ConsoleKey? _keyDown = null;

        private Stopwatch sw;
        private double pollRateMs = 35; // KeyAvailable pollrate seems to average about 33-36ms

        public SimpleConsoleUserInput()
        {
            sw = Stopwatch.StartNew();
        }

        public bool IsKeyDown(ConsoleKey key)
        {
            // In order to make it non-blocking only check when there is a key available.
            // However the polling rate of KeyAvailable is often lower than the frequency which this method is called.
            // The solution is to cache a keypress when avaiable, and only reset if another press does not arrive after a set time.
            if (Console.KeyAvailable)
            {
                _keyDown = Console.ReadKey(true).Key;
                sw.Restart();
            }
            else if (sw.ElapsedMilliseconds > pollRateMs) 
            {
                _keyDown = null;
                sw.Restart();
            }

            return key == _keyDown;
        }

        public char ReadInput()
        {
            return Console.ReadKey(true).KeyChar;
        }
    }
}
