using System;
using ConsoleGame.GameLoop;

namespace ConsoleGame
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            IGame game = new Game();
            Console.WriteLine("Play");
            game.Play();
            Console.ReadKey();
        }
    }
}