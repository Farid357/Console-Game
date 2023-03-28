using System;
using System.Diagnostics;

namespace ConsoleGame.Loop
{
    public sealed class GameLoop : IGameLoop
    {
        private readonly IReadOnlyGamePause _gamePause;
        private readonly IGameLoopObject _loopObject;
        private readonly Stopwatch _stopwatch;
        
        public GameLoop(IReadOnlyGamePause gamePause, IGameLoopObject loopObject)
        {
            _gamePause = gamePause ?? throw new ArgumentNullException(nameof(gamePause));
            _loopObject = loopObject ?? throw new ArgumentNullException(nameof(loopObject));
            _stopwatch = new Stopwatch();
        }

        public void Start()
        {
            _stopwatch.Start();
            TimeSpan lastUpdateTime = _stopwatch.Elapsed;
            float elapsedTime = 0;
            
            while (true)
            {
                if (_gamePause.IsActive)
                    continue;

                TimeSpan deltaTime = _stopwatch.Elapsed - lastUpdateTime;
                lastUpdateTime += deltaTime;
                var deltaTimeInSeconds = (float)deltaTime.TotalSeconds;
                _loopObject.Update(deltaTimeInSeconds);
                Console.WriteLine($"Delta Time: {deltaTimeInSeconds}");
                elapsedTime += deltaTimeInSeconds;
                Console.WriteLine($"Elapsed Time: {elapsedTime}");
                Console.WriteLine($"Real Elapsed Time: {(float)_stopwatch.Elapsed.TotalSeconds}");
            }
        }
    }
}