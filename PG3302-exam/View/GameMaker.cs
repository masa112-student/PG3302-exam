using Domain;
using Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    internal class GameMaker
    {
        public static GameManager MakeGame() {
            GameManager manager;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
                manager = new GameManager(
                new SimpleConsoleRenderer(Console.WindowWidth, Console.WindowHeight),
                new WindowsConsoleUserInput(),
                new GameBoard(Console.WindowWidth, Console.WindowHeight),
                new JsonPersistance()
                );
            }
            else {
                manager = new GameManager(
                new SimpleConsoleRenderer(Console.WindowWidth, Console.WindowHeight),
                new SimpleConsoleUserInput(),
                new GameBoard(Console.WindowWidth, Console.WindowHeight),
                new JsonPersistance()
                );
            }

            return manager; 
        }
    }
}
