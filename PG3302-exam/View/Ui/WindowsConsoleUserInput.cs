using System.Runtime.InteropServices;

namespace View.Ui
{    
    /// <summary>
    /// Input implementation that's only usable on windows as it relies on the win32 api
    /// </summary>
    public class WindowsConsoleUserInput : IUserInput
    {


        [DllImport("User32.dll")]
        public static extern short GetKeyState(int vKey);

        private const ushort MOST_SIGNIFICANT_BIT = 0x8000; // = 10000000 00000000;

        public bool IsKeyDown(ConsoleKey key)
        {
            short result = GetKeyState((int)key);
            return (result & MOST_SIGNIFICANT_BIT) == MOST_SIGNIFICANT_BIT;
        }

        public char ReadInput() 
        {
            return Console.ReadKey(true).KeyChar;
        }
    }
}
