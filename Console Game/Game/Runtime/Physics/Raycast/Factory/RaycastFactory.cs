using System;
using ConsoleGame.Loop;

namespace ConsoleGame.Physics
{
    public sealed class RaycastFactory<T> : IRaycastFactory<T>
    {
        private readonly IGameLoopObjectsGroup _gameLoop;
        private readonly IReadOnlyCollidersWorld<T> _collidersWorld;

        public RaycastFactory(IGameLoopObjectsGroup gameLoop, IReadOnlyCollidersWorld<T> collidersWorld)
        {
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
            _collidersWorld = collidersWorld ?? throw new ArgumentNullException(nameof(collidersWorld));
        }

        public IRaycast<T> Create()
        {
            var raycast = new Raycast<T>(_collidersWorld);
            _gameLoop.Add(raycast);
            return raycast;
        }
    }
}