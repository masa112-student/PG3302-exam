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
            Dimension gameDimension = new(Console.WindowWidth, Console.WindowHeight);
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
                manager = new GameManager(
                new SimpleConsoleRenderer(gameDimension),
                new WindowsConsoleUserInput(),
                new GameBoard(gameDimension),
                new JsonPersistance()
                );
            }
            else {
                manager = new GameManager(
                new SimpleConsoleRenderer(gameDimension),
                new SimpleConsoleUserInput(),
                new GameBoard(gameDimension),
                new JsonPersistance()
                );
            }

            return manager; 
        }
    }
}
