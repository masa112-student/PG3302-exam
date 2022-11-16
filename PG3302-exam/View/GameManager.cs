using Domain.Data;
using Domain.Core;
using Serialization;
using System.Diagnostics;
using System.Text;
using System.Media;

namespace View
{
    internal class GameManager
    {
        private readonly IRenderer _renderer;
        private readonly IPersistance _serializer;
        private readonly IUserInput _userInput;
        private readonly IGameBoard _gameBoard;

        private string _userName = "<<Not set>>";

        public GameManager(IRenderer renderer, IUserInput userInput, IGameBoard gameBoard, IPersistance serializer) {
            _renderer = renderer;
            _serializer = serializer;
            _userInput = userInput;
            _gameBoard = gameBoard;
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
			if (OperatingSystem.IsWindows())
			{
				SoundPlayer menuMusic = new SoundPlayer("menuMusic.wav");
              menuMusic.Load();
              menuMusic.PlayLooping();                
			}
			bool quit = false;
            while (!quit) {
                _renderer.DrawString(0, 0,
                    "Select option\n" +
                    "1: View scores\n" +
                    "2: Play game\n" +
                    "3: Quit\n"
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

            while (!_userInput.IsKeyDown(ConsoleKey.Enter)) ;

            _renderer.ClearScreen();
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


class UserInputFormatter
{
    private StringBuilder _input = new StringBuilder();

    public char LastReadChar { get; private set; }
    public bool UserHitEnter { get; private set; }  

    public void AddInput(char c) {
        LastReadChar = c;
        
        if (c == (char)ConsoleKey.Backspace && _input.Length > 0)
            _input.Remove(_input.Length - 1, 1);
        else if(char.IsLetterOrDigit(c) || c == ' ')
            _input.Append(c);

        UserHitEnter = (c == (char)ConsoleKey.Enter);
    }

    public string GetInputString() {
        _input.Replace("\r", string.Empty);
        _input.Replace("\n'", string.Empty);
        _input.Replace("\b", string.Empty);

        return _input.ToString();
    }
}