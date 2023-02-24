using System;
using Console_Game.Tools;

namespace Console_Game
{
    public sealed class Health : IHealth
    {
        private readonly IHealthView _view;

        public Health(IHealthView view, int value)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            Value = value.ThrowIfLessThanOrEqualsToZeroException();
            MaxValue = Value;
        }

        public int Value { get; private set; }

        public int MaxValue { get; }

        public bool IsAlive => Value > 0;

        private bool IsDied => !IsAlive;
        
        public bool CanTakeDamage(int damage) => Value - damage >= 0;

        public void TakeDamage(int damage)
        {
            if (IsDied)
                throw new InvalidOperationException($"Health can't take damage! It's not alive!");

            if (CanTakeDamage(damage) == false)
                throw new ArgumentOutOfRangeException($"Can take damage: {damage}");
            
            Value -= damage.ThrowIfLessThanOrEqualsToZeroException();
            _view.Visualize(MaxValue, Value);

            if (IsDied)
                _view.Die();
        }
    }
}