using System;
using ConsoleGame.GameLoop;
using ConsoleGame.SaveSystem;

namespace ConsoleGame
{
    public sealed class CharacterMovementFactory : IMovementFactory
    {
        private readonly IGameLoopObjectsGroup _gameLoop;
        private readonly ISaveStorages _saveStorages;

        public CharacterMovementFactory(IGameLoopObjectsGroup gameLoop, ISaveStorages saveStorages)
        {
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
            _saveStorages = saveStorages ?? throw new ArgumentNullException(nameof(saveStorages));
        }

        public IAdjustableMovement Create(ITransform transform)
        {
            ISaveStorage<float> movementSpeedStorage = new BinaryStorage<float>(new Path(nameof(IPlayer) + nameof(IMovement)));
            float speed = movementSpeedStorage.HasSave() ? movementSpeedStorage.Load() : 1.5f;
            _saveStorages.Add(movementSpeedStorage);
            var smoothMovement = new SmoothMovement(transform);
            _gameLoop.Add(smoothMovement);
            return new AdjustableMovement(smoothMovement, speed);
        }
    }
}