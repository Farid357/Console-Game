using System.Collections.Generic;
using System.Numerics;

namespace ConsoleGame
{
    public interface IEnemyWaveData
    {
        IReadOnlyList<(EnemyType EnemyType, int EnemiesCount)> Enemies { get; }

        IReadOnlyList<Vector3> Positions { get; }
    }
}