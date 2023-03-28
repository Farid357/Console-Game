using System;

namespace ConsoleGame
{
    public sealed class EnemyHealthView : IHealthView
    {
        public void Visualize(int value, int maxValue)
        {
            Console.WriteLine($"Enemy Health {value}");
        }

        public void Die()
        {
            Console.WriteLine($"Enemy died!");
        }
    }
}