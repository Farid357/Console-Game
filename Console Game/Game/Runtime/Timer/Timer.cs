using System;
using Console_Game.Tools;

namespace Console_Game
{
    public sealed class Timer : ITimer, IGameLoopObject
    {
        private readonly float _cooldown;
        private float _elapsedTime;
        
        public Timer(float cooldown)
        {
            _cooldown = cooldown.ThrowIfLessOrEqualsToZeroException();
        }

        public bool IsActive { get; private set; }
        
        public bool IsEnded => !IsActive || _elapsedTime >= _cooldown;

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
                _elapsedTime += deltaTime;

                if (IsEnded)
                    Reset();
            }
        }

        private void Reset()
        {
            IsActive = false;
            _elapsedTime = 0;
        }
    }
}