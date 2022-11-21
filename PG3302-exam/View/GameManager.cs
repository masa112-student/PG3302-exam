using System.Diagnostics;

using Domain.Data;
using Domain.Core;
using Domain.Music;

using Serialization;
using View.Ui;

namespace View
{
    /// <summary>
    /// The class that ties everything together, and orchestrates the flow of the app.
    /// 
    /// All the public methods will present the user with a different view
    /// 
    /// StartupView asks and retrieves the name of the user
    /// MenuView presents the user with the options to play the game, view highscores or quit
    /// GameplayView is where the actual game is played
    /// GameOverView is shown at the end of the gameplay, and shows the users score
    /// HighScoreView displays a sorted list of highscores
    /// 
    /// A brief example of how the various components work together:
    ///     In the main gameplayloop input will be read from the supplied IUserInput implementation, which will be passed along to the IGameBoard instance where all the game logic takes place.
    ///     Then the IRenderer fetches all of the sprites from the IGameBoard and render them at a fixed interval.
    ///     
    ///     IPersistance will read all files from storage when HighScoresView is called, and add/update the users score in the GameOverView
    ///     IMusic will play a track relevant for the current view
    /// 
    /// With it relying only on interfaces for the various game components, behaviour can easily be changed with new implementations of the interfaces.
    /// </summary>
    internal class GameManager
    {
        private readonly IRenderer _renderer;
        private readonly IPersistance _persistance;
        private readonly IUserInput _userInput;
        private readonly IGameBoard _gameBoard;
        private readonly IMusicManager _music;

        private string _userName = "<<Not set>>";

        public GameManager(IRenderer renderer, IUserInput userInput,
			IGameBoard gameBoard, IPersistance serializer, IMusicManager music) { 

			_renderer = renderer;
            _persistance = serializer;
            _userInput = userInput;
            _gameBoard = gameBoard;
            _music = music;
        }

        public void StartupView() {
            _music.PlayMenuMuisc();

            UserInputFormatter formatter = new();
            _renderer.CursorVisible = true;
            
            do {
                _renderer.ClearScreen();
                _renderer.DrawString(0, 0, "Enter your name:");
                _renderer.DrawString(0, 1, formatter.GetInputString());

                formatter.AddInput(_userInput.ReadInput());
            } while (!formatter.UserHitEnter);

            _renderer.CursorVisible = false;

            _userName = formatter.GetInputString();

            GreetPlayer();

            MenuView();
        }

        // Skip the greeting for faster statrup when debugging 
        [Conditional("RELEASE")]
        private void GreetPlayer() {
            _renderer.ClearScreen();
            _renderer.DrawString(0, 0, $"Welcome {_userName}!");
            Thread.Sleep(1000);
        }

        public void MenuView() {
            _renderer.ClearScreen();
			bool quit = false;
            const string ASCII_ART_LOGO = "\r\n   _____                           _____                         _                  \r\n  / ____|                         |_   _|                       | |                 \r\n | (___   _ __    __ _   ___  ___   | |   _ __ __   __ __ _   __| |  ___  _ __  ___ \r\n  \\___ \\ | '_ \\  / _` | / __|/ _ \\  | |  | '_ \\\\ \\ / // _` | / _` | / _ \\| '__|/ __|\r\n  ____) || |_) || (_| || (__|  __/ _| |_ | | | |\\ V /| (_| || (_| ||  __/| |   \\__ \\\r\n |_____/ | .__/  \\__,_| \\___|\\___||_____||_| |_| \\_/  \\__,_| \\__,_| \\___||_|   |___/\r\n         | |                                                                        \r\n         |_|                                                                        \r\n\n\n";
            
            while (!quit) {
                _music.PlayMenuMuisc();
                _renderer.DrawString(0, 0,
                     ASCII_ART_LOGO +
					"Select option\n\n\n" +
					"1: View scores\n\n" +
					"2: Play game\n\n" +
					"3: Quit\n\n"
				);

                if (_userInput.IsKeyDown(ConsoleKey.D1)) {
                    HighScoreView();
                }
                if (_userInput.IsKeyDown(ConsoleKey.D2)) {
                    GameView();                    
                }
                if (_userInput.IsKeyDown(ConsoleKey.D3)) {
                    quit = true;
                }
            }
        }

        public void GameView() {
            _music.PlayGameLoopMusic();

            _renderer.ClearScreen();
            _gameBoard.Start();

            Point center = new Point(Console.WindowWidth / 2, Console.WindowHeight / 2);
            Point moveDir = new Point(0, 0);

            Stopwatch framerateTimer = Stopwatch.StartNew();
            double FPS = 15;
            double frameTime = (1.0 / FPS) * 1000;
            bool forceQuit = false;
            while (_gameBoard.IsGameActive && !forceQuit) {

                moveDir.X = 0;

                if (_userInput.IsKeyDown(ConsoleKey.A))
                    _gameBoard.MovePlayer(IGameBoard.MoveDir.Left);
                if (_userInput.IsKeyDown(ConsoleKey.D))
                    _gameBoard.MovePlayer(IGameBoard.MoveDir.Right);
                if (_userInput.IsKeyDown(ConsoleKey.Spacebar))
                    _gameBoard.PlayerAttack();
                if (_userInput.IsKeyDown(ConsoleKey.Q))
                    forceQuit = true;

                if (framerateTimer.ElapsedMilliseconds > frameTime) {
                    _gameBoard.Update();

                    var sprites = _gameBoard.GetSprites();
                    sprites.ForEach(sprite => _renderer.DrawSprite(sprite));

                    _renderer.DrawString(0, _renderer.WindowDimension.Height-1, $"Score: {_gameBoard.Score}");
                    framerateTimer.Restart();
                }
            }

            GameOverView();
        }

        public void GameOverView() {
            _music.PlayGameOverSound();

            var scores = _persistance.LoadHighScores();
            scores.Add(new Score(_userName, _gameBoard.Score));
            _persistance.SaveHighScores(scores);

            _renderer.ClearScreen();
            _renderer.DrawString(0, 0, $"Game over. Score {_gameBoard.Score}");
            _renderer.DrawString(0, 2, "Press enter to return to the menu");


			while (!_userInput.IsKeyDown(ConsoleKey.Enter)) ;

            _renderer.ClearScreen();
		}

        public void HighScoreView() {
            _music.PlayMenuMuisc();

            HighScores scores = _persistance.LoadHighScores();
            _renderer.ClearScreen();
            _renderer.DrawString(0, 0, "HighScores:");

            int y = 1;
            foreach (var score in scores) {
                _renderer.DrawString(0, y++, $"{score.Name,-10}: {score.Points}");
            }

            _renderer.DrawString(0, ++y, "Press enter to return to the menu");

            while (!_userInput.IsKeyDown(ConsoleKey.Enter));

            _renderer.ClearScreen();
        }

    }
}
