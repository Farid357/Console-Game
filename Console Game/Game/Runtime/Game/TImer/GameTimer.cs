using System;
using System.Diagnostics;

namespace Console_Game.Loop
{
    public sealed class GameTimer : IGameTimer
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();

        public bool IsActive { get; private set; }

        public long ElapsedMilliseconds => _stopwatch.ElapsedMilliseconds;

        public void Play()
        {
            if (IsActive)
                throw new InvalidOperationException($"Game Time is already active");

            IsActive = true;
            _stopwatch.Start();
        }
    }
}