using ConsoleGame.GameLoop;
using ConsoleGame.Physics;
using System.Collections.Generic;

namespace ConsoleGame
{
    public interface IReadOnlyEnemiesWorld
    {
        bool EverybodyDied { get; }

        IGameObjectsGroup GameObjectsGroup { get; }

        ICollidersWorld<IEnemy> PhysicsWorld { get; }

        IReadOnlyDictionary<IEnemy, EnemyType> Enemies { get; }
    }
}