using System;
using ConsoleGame.Tools;

namespace ConsoleGame.Shop
{
    public sealed class Good : IGood
    {
        public Good(int cost, string name)
        {
            Cost = cost.ThrowIfLessThanZeroException();
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public string Name { get; }
        
        public int Cost { get; }
        
        public void Use()
        {
            Console.WriteLine($"Good {Name} was used!");
        }
    }
}