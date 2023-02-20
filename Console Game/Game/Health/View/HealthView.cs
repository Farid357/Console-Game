using System;

namespace Console_Game
{
    public sealed class HealthView : IHealthView
    {
        public void Visualize(int maxValue, int value)
        {
            Console.WriteLine($"Health: {maxValue}/{value}");

        }

        public void VisualizeDeath()
        {
            Console.WriteLine($"I'm died!");
        }
    }
}