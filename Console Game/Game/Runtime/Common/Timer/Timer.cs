using System;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class Timer : ITimer, IGameLoopObject
    {
        private float _cooldown;

        public Timer(float cooldown)
        {
            _cooldown = cooldown.ThrowIfLessOrEqualsToZeroException();
        }

        public float Time { get; private set; }

        public bool IsEnded => Time >= _cooldown;

        public void ResetTime()
        {
            Time = 0;
        }

        public void IncreaseCooldown(float amount)
        {
            _cooldown += amount.ThrowIfLessThanZeroException();
        }

        public void DecreaseCooldown(float amount)
        {
            if (_cooldown - amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            _cooldown -= amount.ThrowIfLessThanZeroException();
        }

        public void Update(float deltaTime)
        {
            Time += deltaTime;
        }
    }
}