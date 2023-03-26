using System;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class NumpadKey : INumpadKey
    {
        private readonly IKey _key;

        public NumpadKey(int number, IKey key)
        {
            _key = key ?? throw new ArgumentNullException(nameof(key));
            Number = number.ThrowIfLessThanZeroException();
        }
        
        public int Number { get; }

        public bool IsPressed()
        {
            return _key.IsPressed();
        }
    }
}