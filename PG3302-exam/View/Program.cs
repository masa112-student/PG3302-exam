using System.Diagnostics;
using System.Runtime.InteropServices;
using Domain;
using Serialization;
using DataTypes;

namespace View
{
    internal class Program
    {
        static void Main(string[] args) {
            GameManager manager = new GameManager(
                new SimpleConsoleRenderer(),
                new WindowsConsoleUserInput(),
                new MockGameBoard(),
                new JsonPersistance()
                );

            manager.StartupView();
        }

        static void OldRenderLoop() {
            Console.CursorVisible = false;

            Enemy? enemy = new(Console.BufferWidth);


            Player player = new(Console.BufferWidth);

            Bullet? bullet = null;

            Powerup? powerup = null;

            bool didPowerUp = false;

            while (true) {
                Console.Clear();

                player.Draw();
                if (enemy != null) {
                    enemy.Draw();
                }

                if (bullet != null) {
                    bullet.Draw();
                }

                if (powerup != null) {
                    powerup.Draw();
                }

                if (enemy == null && didPowerUp == false) {
                    powerup = new Powerup(Console.WindowHeight, 100);
                }

                Thread.Sleep(100);


                if (Console.KeyAvailable) {
                    var keypress = Console.ReadKey(true);

                    if (keypress.Key == ConsoleKey.A) {
                        player.XPos -= 1;
                    }
                    if (keypress.Key == ConsoleKey.Spacebar) {
                        bullet = new Bullet(Console.WindowHeight, player.XPos, 500);
                    }

                    if (didPowerUp == true && keypress.Key == ConsoleKey.Spacebar) {
                        bullet = new Bullet(Console.WindowHeight, player.XPos, 200);
                    }
                    else if (keypress.Key == ConsoleKey.D) {
                        player.XPos += 1;
                    }
                }

                if (powerup != null && didPowerUp == false) {
                    if (powerup.XPos == player.XPos) {
                        didPowerUp = true;
                        powerup = null;
                    }
                }

                if (bullet != null && enemy != null) {
                    if (bullet.XPos == enemy.XPos && bullet.YPos == 2) {
                        enemy = null;
                    }
                }
            }
        }
    }
}
