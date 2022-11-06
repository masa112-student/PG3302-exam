using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serialization;
using System.Security.Cryptography.X509Certificates;
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
            s.Replace('\r', '\0');
            s.Replace('\n', '\0');
            s.Replace('\b', '\0');

            _renderer.ClearScreen();
            _renderer.DrawString(0, 0, $"Hello {s.ToString()}!");
            _userInput.ReadInput();
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
            _renderer.DrawString(0, 0, "We gaming?");

            while(_gameBoard.IsGameActive) {
                _gameBoard.Update();
                if (_userInput.IsKeyDown(ConsoleKey.P))
                    _gameBoard.IsGameActive = false;
            }

            GameOverView();
        }

        public void GameOverView() {
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

            _renderer.DrawString(0, ++y, "Press backspace to return");

            while (!_userInput.IsKeyDown(ConsoleKey.Backspace));
            _renderer.ClearScreen();
        }

    }
}
