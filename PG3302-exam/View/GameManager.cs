﻿using Domain;
using Serialization;
using System.Diagnostics;
using System.Text;

namespace View
{
    internal class GameManager
    {
        private IRenderer _renderer;
        private IPersistance _serializer;
        private IUserInput _userInput;
        private IGameBoard _gameBoard;
        private string _userName = "<<Not set>>";

        public GameManager(IRenderer renderer, IUserInput userInput, IGameBoard gameBoard, IPersistance serializer) {
            _renderer = renderer;
            _serializer = serializer;
            _userInput = userInput;
            _gameBoard = gameBoard;
        }

        public void StartupView() {
            UserInputFormatter formatter = new();
            do {
                _renderer.ClearScreen();
                _renderer.DrawString(0, 0, "Enter your name:");
                _renderer.DrawString(0, 1, formatter.GetInputString());
                formatter.AddInput(_userInput.ReadInput());

            } while (formatter.LastReadChar != '\r');
            _userName = formatter.GetInputString();

            _renderer.ClearScreen();

            GreetPlayer();

            MenuView();
        }

        [Conditional("RELEASE")]
        private void GreetPlayer() {
            _renderer.DrawString(0, 0, $"Welcome {_userName}!");
            Thread.Sleep(1000);
        }

        public void MenuView() {
            _renderer.ClearScreen();
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
            Stopwatch framerateTimer = Stopwatch.StartNew();

            double FPS = 15;
            double frameTime = (1.0 / FPS) * 1000;
            Point moveDir = new Point(0, 0);
            //int CLEAR = 10;
            while (!_userInput.IsKeyDown(ConsoleKey.Q)) {

                moveDir.X = 0;

                if (_userInput.IsKeyDown(ConsoleKey.A))
                    _gameBoard.MovePlayer(IGameBoard.MoveDir.Left);
                if (_userInput.IsKeyDown(ConsoleKey.D))
                    _gameBoard.MovePlayer(IGameBoard.MoveDir.Right);
                if (_userInput.IsKeyDown(ConsoleKey.Spacebar))
                    _gameBoard.PlayerAttack();

                if (framerateTimer.ElapsedMilliseconds > frameTime) {
                    _gameBoard.Update();

                    var sprites = _gameBoard.GetSprites();
                    sprites.ForEach(sprite => _renderer.DrawSprite(sprite));
                    framerateTimer.Restart();

                    //if(CLEAR <= 0) {
                    //    _renderer.ClearScreen();
                    //    CLEAR = 10;
                    //}
                    //CLEAR--;
                }
            }

            GameOverView();
        }

        public void GameOverView() {
            var scores = _serializer.LoadHighScores();
            scores.UpdateScore(new Score(_userName, _gameBoard.Score));
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
            foreach (var score in scores.Scores) {
                _renderer.DrawString(0, y++, $"{score.Name,-10}: {score.Points}");
            }

            _renderer.DrawString(0, ++y, "Press enter to return to the menu");

            while (!_userInput.IsKeyDown(ConsoleKey.Enter)) ;
            _renderer.ClearScreen();
        }

    }
}


class UserInputFormatter
{
    private StringBuilder _input = new StringBuilder();

    public char LastReadChar { get; private set; }

    public void AddInput(char c) {
        LastReadChar = c;
        if (c == (char)ConsoleKey.Backspace && _input.Length > 0)
            _input.Remove(_input.Length - 1, 1);
        else
            _input.Append(c);
    }

    public string GetInputString() {
        _input.Replace("\r", string.Empty);
        _input.Replace("\n'", string.Empty);
        _input.Replace("\b", string.Empty);

        return _input.ToString();
    }
}