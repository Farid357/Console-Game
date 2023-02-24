using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Console_Game.Loop
{
    public sealed class GameTime : IGameTime
    {
        private readonly Stopwatch _stopwatch;
        private long _previousUpdateTime;
        
        public GameTime()
        {
            _stopwatch = new Stopwatch();
        }

        public bool IsActive => _stopwatch.IsRunning;

        public long ElapsedMilliseconds => _stopwatch.ElapsedMilliseconds;

        public long TimeBetweenFrames { get; private set; }
        
        public void Play()
        {
            if (IsActive)
                throw new InvalidOperationException($"Game Time is already active");

            _stopwatch.Start();
            CalculateTimeBetweenFrames();
        }

        private async void CalculateTimeBetweenFrames()
        {
            while (true)
            {
                TimeBetweenFrames = ElapsedMilliseconds - _previousUpdateTime;
                await Task.Delay(TimeSpan.FromMilliseconds(TimeBetweenFrames));
                _previousUpdateTime = ElapsedMilliseconds;
            }
        }

        public void Stop()
        {
            if (IsActive == false)
                throw new InvalidOperationException($"Game Time is already not active");

            _stopwatch.Stop();
        }
    }
}