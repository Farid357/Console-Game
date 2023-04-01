using System.Collections.Generic;

namespace ConsoleGame.Wave
{
    public sealed class Wave : IWave
    {
        public Wave(IReadOnlyList<(EnemyType EnemyType, int EnemiesCount)> enemies)
        {
            Enemies = enemies;
        }

        public IReadOnlyList<(EnemyType EnemyType, int EnemiesCount)> Enemies { get; }
    }
}