using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleGame.GameLoop;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class ShootersSimulation<TShooter, TWeapon> : IShootersSimulation<TShooter, TWeapon> where TShooter : IShooter<TWeapon>
    {
        private readonly IGameLoopObjectsGroup _gameLoop;
        private readonly List<TShooter> _shooters = new List<TShooter>();
        private TShooter _currentShooter;

        public ShootersSimulation(IGameLoopObjectsGroup gameLoop)
        {
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
        }

        public IReadOnlyList<IReadOnlyShooter<TWeapon>> Players => _shooters.ToReadOnly<TShooter, TWeapon>();

        public IReadOnlyShooter<TWeapon> CurrentShooter => _currentShooter;

        public bool HasPlayer() => CurrentShooter != null;

        public void Add(TShooter shooter)
        {
            _shooters.Add(shooter);
            _gameLoop.Add(shooter);
            _currentShooter = shooter;
        }

        public void DeleteCurrentPlayer()
        {
            if (HasPlayer() == false)
                throw new InvalidOperationException($"Simulation doesn't have player!");

            _shooters.Remove(_currentShooter);
            _gameLoop.Remove(_currentShooter);

            if (_shooters.Count > 0)
                _currentShooter = _shooters.Last();
        }
    }
}