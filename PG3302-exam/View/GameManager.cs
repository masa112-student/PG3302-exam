using System.Diagnostics;

using Domain.Data;
using Domain.Core;
using Domain.Music;

using Serialization;
using View.Ui;

namespace View
{
    internal class GameManager
    {
        private readonly IRenderer _renderer;
        private readonly IPersistance _serializer;
        private readonly IUserInput _userInput;
        private readonly IGameBoard _gameBoard;
        private readonly IMusic _music;

        private string _userName = "<<Not set>>";

        public GameManager(IRenderer renderer, IUserInput userInput,
			IGameBoard gameBoard, IPersistance serializer, IMusic music){ 

			_renderer = renderer;
            _serializer = serializer;
            _userInput = userInput;
            _gameBoard = gameBoard;
            _music = music;
        }

        public void StartupView() {
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

        [Conditional("RELEASE")]
        private void GreetPlayer() {
            _renderer.ClearScreen();
            _renderer.DrawString(0, 0, $"Welcome {_userName}!");
            Thread.Sleep(1000);
        }

        public void MenuView() {
            _renderer.ClearScreen();
            _music.PlayMenuMuisc();
			bool quit = false;
            while (!quit) {
                _renderer.DrawString(0, 0,
					"\r\n   _____                           _____                         _                  \r\n  / ____|                         |_   _|                       | |                 \r\n | (___   _ __    __ _   ___  ___   | |   _ __ __   __ __ _   __| |  ___  _ __  ___ \r\n  \\___ \\ | '_ \\  / _` | / __|/ _ \\  | |  | '_ \\\\ \\ / // _` | / _` | / _ \\| '__|/ __|\r\n  ____) || |_) || (_| || (__|  __/ _| |_ | | | |\\ V /| (_| || (_| ||  __/| |   \\__ \\\r\n |_____/ | .__/  \\__,_| \\___|\\___||_____||_| |_| \\_/  \\__,_| \\__,_| \\___||_|   |___/\r\n         | |                                                                        \r\n         |_|                                                                        \r\n\n\n" +

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
            _renderer.ClearScreen();
            _gameBoard.Start();
            _music.PlayGameLoopMusic();
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
            var scores = _serializer.LoadHighScores();
            scores.Add(new Score(_userName, _gameBoard.Score));
            _serializer.SaveHighScores(scores);

            _renderer.ClearScreen();
            _renderer.DrawString(0, 0, $"Game over. Score {_gameBoard.Score}");
            _renderer.DrawString(0, 2, "Press enter to return to the menu");

            _music.PlayGameOverSound();

			while (!_userInput.IsKeyDown(ConsoleKey.Enter)) ;

            _renderer.ClearScreen();
            _music.PlayMenuMuisc();
		}

        public void HighScoreView() {
            HighScores scores = _serializer.LoadHighScores();
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
