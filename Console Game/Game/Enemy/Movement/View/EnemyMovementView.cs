using System;
using System.Numerics;

namespace Console_Game
{
    public sealed class EnemyMovementView : IEnemyMovementView
    {
        public void Visualize(Vector2 position)
        {
            Console.WriteLine($"Enemy position {position}");
        }
    }
}