using System.Diagnostics;

namespace View
{
    internal class Program
    {
        static void Main(string[] args) {
            Console.CursorVisible = false;
            Console.SetWindowSize(50, 20);
            Console.SetBufferSize(50, 20);

			Enemy enemy = new(Console.BufferWidth);


			Player player = new(Console.BufferWidth);
            while (true) {
               Console.Clear();

                player.Draw();
                enemy.Draw();
                Thread.Sleep(100);


                if (Console.KeyAvailable) {
					var keypress = Console.ReadKey(true);

					if (keypress.Key == ConsoleKey.A)
					{
						player.XPos -= 1;
					}
					else if (keypress.Key == ConsoleKey.D)
					{
						player.XPos += 1;
					}
				}

                
            }
        }
    }
}