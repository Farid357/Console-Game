using System;

namespace ConsoleGame
{
    public static class Program
    {
        static void Main(string[] args)
        {
            IGame game = new Game();
            Console.WriteLine("Play");
            game.Play();
            Console.ReadKey();
        }
    }
}