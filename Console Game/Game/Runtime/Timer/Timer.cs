using System;
using Console_Game.Tools;

namespace Console_Game
{
    public sealed class Timer : ITimer, IGameLoopObject
    {
        private readonly float _cooldown;

        public Timer(float cooldown)
        {
            _cooldown = cooldown.ThrowIfLessOrEqualsToZeroException();
        }

        public bool IsActive { get; private set; }
        
        public float Time { get; private set; }
        
        public bool IsEnded => !IsActive || Time >= _cooldown;

        public void Play()
        {
            if (IsActive)
                throw new InvalidOperationException($"Timer is already playing!");

            IsActive = true;
        }

        public void Update(float deltaTime)
        {
            if (IsActive)
            {
                Time += deltaTime;

                if (IsEnded)
                    Reset();
            }
        }

        private void Reset()
        {
            IsActive = false;
            Time = 0;
        }
    }
}