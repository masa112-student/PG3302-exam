using System.Diagnostics;
using System.Runtime.InteropServices;
using Domain;
using Serialization;

namespace View
{
    internal class Program
    {
        static void Main(string[] args) {
            GameManager manager;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
                manager = new GameManager(
                new SimpleConsoleRenderer(),
                new WindowsConsoleUserInput(),
                new GameBoard(Console.WindowWidth, Console.WindowHeight),
                new JsonPersistance()
                );
            }
            else {
                manager = new GameManager(
                new SimpleConsoleRenderer(),
                new SimpleConsoleUserInput(),
                new GameBoard(Console.WindowWidth, Console.WindowHeight),
                new JsonPersistance()
                );
            }
            manager.StartupView();
        }

    }
}
