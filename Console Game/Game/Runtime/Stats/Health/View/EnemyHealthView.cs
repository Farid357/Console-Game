using System;

namespace ConsoleGame
{
    public sealed class EnemyHealthView : IHealthView
    {
        public void Visualize(int health, int maxHealth)
        {
            Console.WriteLine($"Enemy Health {health}");
        }

        public void Die()
        {
            Console.WriteLine($"Enemy died!");
        }
    }
}