using System.Collections.Generic;

namespace ConsoleGame
{
    public interface IEnemiesWorld
    {
        bool EverybodyDied { get; }

        IReadOnlyDictionary<IEnemy, EnemyType> Enemies { get; }

        void Add(IEnemy enemy, EnemyType type);

        void Clear();
    }
}