using System;

namespace Console_Game
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