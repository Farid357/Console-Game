using System;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class Timer : ITimer, IGameLoopObject
    {
        private readonly float _cooldown;

        public Timer(float cooldown)
        {
            _cooldown = cooldown.ThrowIfLessOrEqualsToZeroException();
        }

        public bool IsActive { get; private set; } = true;
        
        public float Time { get; private set; }
        
        public bool IsEnded => !IsActive || Time >= _cooldown;

        public void Play() => IsActive = true;

        public void Stop() => IsActive = false;

        public void ResetTime()
        {
            Time = 0;
        }

        public void Update(float deltaTime)
        {
            if (IsActive)
            {
                Time = Math.Min(Time + _cooldown, _cooldown);
            }
        }
    }
}