using System;
using Console_Game.Tools.Extensions;

namespace Console_Game
{
    public sealed class Timer : ITimer, IUpdateable
    {
        private readonly float _cooldown;
        private bool _isActive;
        private float _elapsedTime;

        public Timer(float cooldown)
        {
            _cooldown = cooldown.ThrowIfLessOrEqualsToZeroException();
        }

        public bool FinishedCountdown => _elapsedTime >= _cooldown;

        public void Play()
        {
            if (_isActive)
                throw new InvalidOperationException($"Timer is already playing!");

            _isActive = true;
        }

        public void Update(float deltaTime)
        {
            if (_isActive)
            {
                _elapsedTime += deltaTime;

                if (FinishedCountdown)
                    Reset();
            }
        }

        private void Reset()
        {
            _isActive = false;
            _elapsedTime = 0;
        }
    }
}