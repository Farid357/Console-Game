using System;
using ConsoleGame.Tests;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class Health : IHealth
    {
        private readonly IHealthView _view;
        private readonly int _maxValue;

        public Health(IHealthView view, int value)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _maxValue = Value = value.ThrowIfLessThanOrEqualsToZeroException();
        }

        public Health(int value) : this(new DummyHealthView(), value)
        {
            
        }
        public int Value { get; private set; }

        public bool IsAlive => Value > 0;

        public bool CanHeal(int value) => true;

        public void Heal(int value)
        {
            if (CanHeal(value) == false)
                throw new InvalidOperationException($"Can't heal for value: {value}");
            
            Value += value.ThrowIfLessThanOrEqualsToZeroException();
            _view.Visualize(Value, _maxValue);
        }

        public void TakeDamage(int damage)
        {
            if (!IsAlive)
                throw new InvalidOperationException($"Health isn't alive!");

            Value -= damage.ThrowIfLessThanZeroException();
            _view.Visualize(Value, _maxValue);
            
            if(!IsAlive)
                _view.Die();
        }
    }
}