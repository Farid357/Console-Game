using System;

namespace ConsoleGame
{
    public sealed class HealthView : IHealthView
    {
        public void Visualize(int maxValue, int value)
        {
            Console.WriteLine($"Health: {maxValue}/{value}");

        }

        public void Die()
        {
            Console.WriteLine($"I'm died!");
        }
    }
}