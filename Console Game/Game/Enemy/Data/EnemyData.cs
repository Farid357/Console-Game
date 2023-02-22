using System;
using System.ComponentModel;

namespace Console_Game
{
    public sealed class EnemyData : IEnemyData
    {
        public EnemyData(EnemyType enemyType, string name)
        {
            if (!Enum.IsDefined(typeof(EnemyType), enemyType))
                throw new InvalidEnumArgumentException(nameof(enemyType), (int)enemyType, typeof(EnemyType));
            
            EnemyType = enemyType;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public EnemyType EnemyType { get; }
        
        public string Name { get; }
    }
}