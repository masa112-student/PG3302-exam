﻿using System.Text;
using Serialization;
using DataTypes;
using Domain;
using System.Diagnostics;

namespace View
{
    internal class GameManager
    {
        private IRenderer _renderer;
        private IPersistance _serializer;
        private IUserInput _userInput;
        private IGameBoard _gameBoard;
        private string _userName = "Not set";

        public GameManager(IRenderer renderer, IUserInput userInput, IGameBoard gameBoard, IPersistance serializer) {
            _renderer = renderer;
            _serializer = serializer;
            _userInput = userInput;
            _gameBoard = gameBoard;
        }

        public void StartupView() {

            char c;
            StringBuilder s = new StringBuilder();
            do {
                _renderer.ClearScreen();
                _renderer.DrawString(0, 0, "Enter your name:");
                _renderer.DrawString(0, 1, s.ToString());
                c = _userInput.ReadInput();
                if (c == (char)ConsoleKey.Backspace && s.Length > 0)
                    s.Remove(s.Length-1, 1);
                else
                    s.Append(c);
            } while (c != '\r');
            s.Replace("\r", string.Empty);
            s.Replace("\n'", string.Empty);
            s.Replace("\b", string.Empty);

            _userName = s.ToString();

            _renderer.ClearScreen();
            _renderer.DrawString(0, 0, $"Welcome {_userName}!");
            Thread.Sleep(1000);

            MenuView();
        }

        public void MenuView() {
            _renderer.ClearScreen();
            bool quit = false;
            while (!quit) {
                _renderer.DrawString(0, 0, 
                    "Select option\n"   +
                    "1: View scores\n"    +
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

            Point center = new Point(Console.WindowWidth / 2, Console.WindowHeight / 2);
            Sprite test = new("  ^  \n ^^^ ", center);
            Stopwatch sw = Stopwatch.StartNew();

            double FPS = 15;
            double frameTime = (1.0 / FPS) * 1000;
            Point moveDir = new Point(0, 0);

            while (!_userInput.IsKeyDown(ConsoleKey.Q)) {

                moveDir.X = 0;

                if (_userInput.IsKeyDown(ConsoleKey.A))
                    moveDir.X = -1;
                if (_userInput.IsKeyDown(ConsoleKey.D))
                    moveDir.X = 1;
                //if (i.IsKeyDown(ConsoleKey.Spacebar))
                //    Trace.WriteLine("Bang!");

                if (sw.ElapsedMilliseconds > frameTime) {
                    test.Pos += moveDir;

                    _renderer.DrawSprite(test);
                    sw.Restart();
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
            while (!_userInput.IsKeyDown(ConsoleKey.Enter));
            
            _renderer.ClearScreen();
        }

        public void HighScoreView() {
            HighScores scores = _serializer.LoadHighScores();
            _renderer.ClearScreen();
            _renderer.DrawString(0, 0, "HighScores:");
            int y = 1;
            foreach(var score in scores.Scores) {
                _renderer.DrawString(0, y++, $"{score.Name,-10}: {score.Points}");
            }

            _renderer.DrawString(0, ++y, "Press enter to return to the menu");

            while (!_userInput.IsKeyDown(ConsoleKey.Enter));
            _renderer.ClearScreen();
        }

    }
}