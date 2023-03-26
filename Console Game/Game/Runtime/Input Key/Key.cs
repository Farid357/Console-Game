using System;

namespace ConsoleGame
{
    public sealed class Key : IKey
    {
        private readonly ConsoleKey _key;

        public Key(ConsoleKey key)
        {
            _key = key;
        }

        public bool IsPressed()
        {
            ConsoleKey consoleKey = Console.ReadKey().Key;
            return consoleKey == _key;
        }
    }
}