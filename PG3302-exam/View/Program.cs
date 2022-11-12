using Domain;
using Serialization;
using System.Runtime.InteropServices;

namespace View
{
    internal class Program
    {
        static void Main(string[] args) {
            GameManager manager = GameMaker.MakeGame();
            manager.StartupView();
        }

    }
}
