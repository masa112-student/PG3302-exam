using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public class WindowsConsoleUserInput : IUserInput
    {

        //[DllImport("User32.dll")]
        //public static extern short GetAsyncKeyState(int vKey);

        [DllImport("User32.dll")]
        public static extern short GetKeyState(int vKey);

        private static readonly ushort MOST_SIGNIFICANT_BIT = 0x8000; // = 10000000 00000000;

        public bool IsKeyDown(ConsoleKey key) {
            short result = GetKeyState((int)key);
            return (result & MOST_SIGNIFICANT_BIT) == MOST_SIGNIFICANT_BIT;
        }

        public char ReadInput() {
            return Console.ReadKey(true).KeyChar;
        }
    }
}
