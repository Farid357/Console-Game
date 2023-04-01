using System.Collections.Generic;

namespace ConsoleGame.Wave
{
    public interface IWaveData
    {
        IReadOnlyList<(EnemyType EnemyType, int EnemiesCount)> Enemies { get; }
    }
}