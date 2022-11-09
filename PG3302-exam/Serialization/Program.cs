namespace Serialization
{
    internal class Program
    {
        static void Main(string[] args) {
            JsonPersistance serializer = new JsonPersistance();

            HighScores highScores = serializer.LoadHighScores();

            bool quit = false;
            while (!quit) {
                Console.Clear();
                Console.WriteLine("Select option");
                Console.WriteLine("1: Add score");
                Console.WriteLine("2: Remove score");
                Console.WriteLine("3: List score");

                ConsoleKeyInfo keyPress = Console.ReadKey(true);

                if (keyPress.Key == ConsoleKey.D1) {
                    Console.WriteLine("Enter your name:");

                    string? name = Console.ReadLine();

                    Console.WriteLine("Enter score:");

                    string? score = Console.ReadLine();
                    int points = int.Parse(string.IsNullOrEmpty(score) ? "0" : score);

                    Score newScore = new Score(name, points);

                    highScores.UpdateScore(newScore);
                    serializer.SaveHighScores(highScores);
                }
                if (keyPress.Key == ConsoleKey.D2) {
                    Console.WriteLine("Enter your name:");

                    string? name = Console.ReadLine();

                    highScores.DeleteScore(name);
                    serializer.SaveHighScores(highScores);
                }
                if (keyPress.Key == ConsoleKey.D3) {

                    foreach (var score in highScores.Scores) {
                        Console.WriteLine($"{score.Name}: {score.Points}");
                    }

                    Console.WriteLine("press any key to continue...");
                    Console.ReadKey();
                }

                if (keyPress.Key == ConsoleKey.Escape) { quit = true; }
            }
        }
    }
}