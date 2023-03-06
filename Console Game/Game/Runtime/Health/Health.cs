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
        
        public bool CanTakeDamage(int damage) => Value - damage >= 0 && IsAlive;

        public bool CanHeal(int value) => MaxValue >= Value + value;

        public void Heal(int value)
        {
            if (CanHeal(value) == false)
                throw new InvalidOperationException($"Can't heal!");

            Value += value.ThrowIfLessThanOrEqualsToZeroException();
            _view.Visualize(MaxValue, Value);
        }

        public void TakeDamage(int damage)
        {
            if (CanTakeDamage(damage) == false)
                throw new ArgumentOutOfRangeException($"Can't take damage: {damage}");
            
            Value -= damage.ThrowIfLessThanZeroException();
            _view.Visualize(MaxValue, Value);

            if (IsAlive == false)
                _view.Die();
        }
    }
}