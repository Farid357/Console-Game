using System;
using System.Collections.Generic;
using System.Numerics;

namespace ConsoleGame
{
    public sealed class EnemyWaveData : IEnemyWaveData
    {
        public EnemyWaveData(IReadOnlyList<(EnemyType EnemyType, int EnemiesCount)> enemies, IReadOnlyList<Vector3> positions)
        {
            Enemies = enemies ?? throw new ArgumentNullException(nameof(enemies));
            Positions = positions ?? throw new ArgumentNullException(nameof(positions));

            if (enemies.Count == 0)
                throw new ArgumentException("Value cannot be an empty collection.", nameof(enemies));
            
            if (positions.Count == 0)
                throw new ArgumentException("Value cannot be an empty collection.", nameof(positions));
        }

        public IReadOnlyList<(EnemyType EnemyType, int EnemiesCount)> Enemies { get; }
        
        public IReadOnlyList<Vector3> Positions { get; }
    }
}