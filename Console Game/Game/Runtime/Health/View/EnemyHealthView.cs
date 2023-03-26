using System;

namespace ConsoleGame
{
    public sealed class EnemyHealthView : IHealthView
    {
        public void Visualize(int maxValue, int value)
        {
            Console.WriteLine($"Enemy Health {value}");
        }

        public void Die()
        {
            Console.WriteLine($"Enemy died!");
        }
    }
}