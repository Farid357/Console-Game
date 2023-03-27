using System;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class Health : IHealth
    {
        public Health(int value)
        {
            Value = value.ThrowIfLessThanOrEqualsToZeroException();
        }
        
        public int Value { get; private set; }
        
        public bool IsAlive => Value > 0;
        
        public bool CanHeal(int value) => true;

        public void Heal(int value)
        {
            Value += value.ThrowIfLessThanOrEqualsToZeroException();
        }

        public void TakeDamage(int damage)
        {
            if (!IsAlive)
                throw new InvalidOperationException($"Health isn't alive!");
            
            Value -= damage.ThrowIfLessThanZeroException();
        }
    }
}