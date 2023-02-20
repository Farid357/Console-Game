using System;
using Console_Game.Tools.Extensions;

namespace Console_Game
{
    public sealed class Health : IHealth
    {
        private readonly IHealthView _view;
        private readonly int _maxValue;
        
        public Health(IHealthView view, int value)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            Value = value.ThrowIfLessThanOrEqualsToZeroException();
            _maxValue = Value;
        }

        public int Value { get; private set; }

        public bool IsAlive => Value > 0;

        public bool IsDied => Value == 0;

        public void TakeDamage(int damage)
        {
            if (IsDied)
                throw new InvalidOperationException($"Health can't take damage! It's not alive!");

            Value = Math.Min(0, Value - damage.ThrowIfLessThanOrEqualsToZeroException());
            _view.Visualize(_maxValue, Value);

            if (IsDied)
                _view.VisualizeDeath();
        }

        public void Heal(int value)
        {
            Value += value.ThrowIfLessThanOrEqualsToZeroException();
            _view.Visualize(_maxValue, Value);
        }
    }
}