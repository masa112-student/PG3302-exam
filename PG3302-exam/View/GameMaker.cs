using Serialization;
using System.Runtime.InteropServices;

using Domain.Data;
using Domain.Core;
using Domain.Music;
using View.Ui;


namespace View
{
    /// <summary>
    /// A factory class responsible for creating and injecting the relevant implementations for the users OS
    /// </summary>
    internal class GameMaker
    {
        public static GameManager MakeGame() {
            GameManager manager;
            Dimension gameDimension = new(Console.WindowWidth, Console.WindowHeight-1);
            Dimension renderDimension = new(Console.WindowWidth, Console.WindowHeight);
            string scoreFileName = "highscores.json";

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
                manager = new GameManager(
                new SimpleConsoleRenderer(renderDimension),
                new WindowsConsoleUserInput(),
                new GameBoard(gameDimension),
                new JsonPersistance(scoreFileName),
				new WindowsMusicManager()				
                );
            }
            else {
                manager = new GameManager(
                new SimpleConsoleRenderer(renderDimension),
                new SimpleConsoleUserInput(),
                new GameBoard(gameDimension),
                new JsonPersistance(scoreFileName),
				new NoMusicManager() 
                );                
            }
            return manager; 
        }
    }
}
