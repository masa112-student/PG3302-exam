using Domain;
using Domain.Data;
using Domain.Core;
using Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Domain.Music;

namespace View
{
    internal class GameMaker
    {
        public static GameManager MakeGame() {
            GameManager manager;
            Dimension gameDimension = new(Console.WindowWidth, Console.WindowHeight);
            string scoreFileName = "highscores.json";

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
                manager = new GameManager(
                new SimpleConsoleRenderer(gameDimension),
                new WindowsConsoleUserInput(),
                new GameBoard(gameDimension),
                new JsonPersistance(scoreFileName),
				new WindowsMusicManager()				
                );
            }
            else {
                manager = new GameManager(
                new SimpleConsoleRenderer(gameDimension),
                new SimpleConsoleUserInput(),
                new GameBoard(gameDimension),
                new JsonPersistance(scoreFileName),
				new MusicManager() 
                );                
            }
            return manager; 
        }
    }
}
