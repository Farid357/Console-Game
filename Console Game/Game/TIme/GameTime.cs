using System;

namespace Console_Game.Loop
{
    public sealed class GameTime : IGameTime
    {
        public bool IsActive { get; private set; }

        public float Delta { get; private set; } = 0.01f;

        public void Play()
        {
            if (IsActive)
                throw new InvalidOperationException($"Game Time is already active");

            IsActive = true;
            Delta = 0.01f;
        }

        public void Stop()
        {
            if (IsActive == false)
                throw new InvalidOperationException($"Game Time is already not active");

            IsActive = false;
            Delta = 0f;
        }
    }
}