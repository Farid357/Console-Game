using System;

namespace Console_Game
{
    public sealed class EnemyHealthView : IHealthView
    {
        public void Visualize(int maxValue, int value)
        {
            Console.WriteLine($"Enemy Health {value}");
        }

        public void VisualizeDeath()
        {
            Console.WriteLine($"Enemy died!");
        }
    }
}