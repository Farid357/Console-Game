using System;

namespace ConsoleGame
{
    public sealed class Program
    {
        public static void Main()
        {
            IGame game = new Game();
            game.Play();
            Console.ReadKey();
        }
    }
}