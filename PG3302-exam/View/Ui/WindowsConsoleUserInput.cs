using System.Runtime.InteropServices;

namespace View.Ui
{    
    /// <summary>
    /// Input implementation that's only usable on windows as it relies on the win32 api
    /// </summary>
    public class WindowsConsoleUserInput : IUserInput
    {
        // Reference: https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getkeystate
        [DllImport("User32.dll")]
        public static extern short GetKeyState(int vKey);

        private const ushort MOST_SIGNIFICANT_BIT = 0x8000; // = 10000000 00000000;

        public bool IsKeyDown(ConsoleKey key)
        {
            /* From the docs: "If the high-order bit is 1, the key is down; otherwise, it is up."
             * 
             * So the process to check for a key down is to and it with the most significant bit in order to remove irrelevant data. Then check it the most significant bit is set.
             * ex (with smaller vals):
             *  result = 1001
             *  MSB = 1000
             *  result & MSB = 1000
             *  return result == MSB 
             */
            short result = GetKeyState((int)key);
            return (result & MOST_SIGNIFICANT_BIT) == MOST_SIGNIFICANT_BIT;
        }

        public char ReadInput() 
        {
            return Console.ReadKey(true).KeyChar;
        }
    }
}
