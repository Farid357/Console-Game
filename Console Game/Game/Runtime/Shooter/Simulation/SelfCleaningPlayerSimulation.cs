using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    public sealed class SelfCleaningShooterSimulation<TShooter, TWeapon> : IShootersSimulation<TShooter, TWeapon>
    {
        private readonly IShootersSimulation<TShooter, TWeapon> _shootersSimulation;

        public SelfCleaningShooterSimulation(IShootersSimulation<TShooter, TWeapon> shootersSimulation)
        {
            _shootersSimulation = shootersSimulation ?? throw new ArgumentNullException(nameof(shootersSimulation));
        }

        public void Add(TShooter shooter)
        {
            if (HasPlayer())
                DeleteCurrentPlayer();
            
            _shootersSimulation.Add(shooter);
        }

        public void DeleteCurrentPlayer()
        {
            _shootersSimulation.DeleteCurrentPlayer();
        }

        public IReadOnlyList<IReadOnlyShooter<TWeapon>> Players => _shootersSimulation.Players;

        public IReadOnlyShooter<TWeapon> CurrentShooter => _shootersSimulation.CurrentShooter;

        public bool HasPlayer()
        {
            return _shootersSimulation.HasPlayer();
        }
    }
}