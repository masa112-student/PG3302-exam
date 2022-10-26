using System.Diagnostics;

namespace View
{
    internal class Program
    {
        static void Main(string[] args) {
            Console.CursorVisible = false;

            Enemy? enemy = new(Console.BufferWidth);


            Player player = new(Console.BufferWidth);

            Bullet? bullet = null;

            while (true) {
                Console.Clear();

                player.Draw();
                if (enemy != null) {
                    enemy.Draw();
                }

                if (bullet != null) {
                    bullet.Draw();
                }

                Thread.Sleep(100);


                if (Console.KeyAvailable) {
                    var keypress = Console.ReadKey(true);

                    if (keypress.Key == ConsoleKey.A) {
                        player.XPos -= 1;
                    }
                    if (keypress.Key == ConsoleKey.Spacebar) {
                        bullet = new Bullet(Console.WindowHeight, player.XPos);
                    }
                    else if (keypress.Key == ConsoleKey.D) {
                        player.XPos += 1;
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