using System;
using ConsoleGame.GameLoop;

namespace ConsoleGame
{
    public sealed class ShootersSimulationFactory : IShootersSimulationFactory
    {
        private readonly IGameLoopObjectsGroup _gameLoop;

        public ShootersSimulationFactory(IGameLoopObjectsGroup gameLoop)
        {
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
        }

        public IShootersSimulation<TShooter, TWeapon> Create<TShooter, TWeapon>() where TShooter : IShooter<TWeapon>
        {
            IShootersSimulation<TShooter, TWeapon> simulation = new ShootersSimulation<TShooter, TWeapon>(_gameLoop);
            return new SelfCleaningShooterSimulation<TShooter, TWeapon>(simulation);
        }
    }
}