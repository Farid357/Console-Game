using System;
using System.Threading.Tasks;
using ConsoleGame.Stats;
using ConsoleGame.Tools;

namespace ConsoleGame.Bonus
{
    public sealed class IncreaseFactorBonus : IBonus
    {
        private readonly IFactor _factor;
        private readonly IBonus _bonus;
        private readonly int _newFactor;
        private readonly float _resetFactorSeconds;

        public IncreaseFactorBonus(IBonus bonus, IFactor factor, float resetFactorSeconds, int newFactor = 2)
        {
            _factor = factor ?? throw new ArgumentNullException(nameof(factor));
            _bonus = bonus ?? throw new ArgumentNullException(nameof(bonus));
            _newFactor = newFactor.ThrowIfLessThanOrEqualsToZeroException();
            _resetFactorSeconds = resetFactorSeconds.ThrowIfLessThanZeroException();
        }
        
        public bool IsAlive => _bonus.IsAlive;

        public async void Pick()
        {
            _bonus.Pick();
            _factor.Increase(_newFactor - 1);
            await Task.Delay(TimeSpan.FromSeconds(_resetFactorSeconds));
            _factor.Reset();
        }

    }
}