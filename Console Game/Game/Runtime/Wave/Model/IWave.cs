using System.Collections.Generic;

namespace ConsoleGame.Wave
{
    public interface IWave
    {
        IReadOnlyList<(EnemyType EnemyType, int EnemiesCount)> Enemies { get; }
    }
}