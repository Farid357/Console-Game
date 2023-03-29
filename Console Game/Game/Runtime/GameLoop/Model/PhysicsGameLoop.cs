using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ConsoleGame.GameLoop
{
    public sealed class PhysicsGameLoop : IGameLoop
    {
        private readonly IReadOnlyGamePause _gamePause;
        private readonly IGameLoopObject _gameLoopObject;
        private readonly Stopwatch _stopwatch;
        private readonly float _fixedTimeStep = 0.2f;

        public PhysicsGameLoop(IReadOnlyGamePause gamePause, IGameLoopObject gameLoopObject)
        {
            _gamePause = gamePause ?? throw new ArgumentNullException(nameof(gamePause));
            _gameLoopObject = gameLoopObject ?? throw new ArgumentNullException(nameof(gameLoopObject));
            _stopwatch = new Stopwatch();
        }

        public async void Start()
        {
            _stopwatch.Start();
            TimeSpan lastUpdateTime = _stopwatch.Elapsed;
            
            while (true)
            {
                if(_gamePause.IsActive)
                    continue;

                await Task.Delay(TimeSpan.FromSeconds(_fixedTimeStep * 1000));
                float deltaTime = (float)(_stopwatch.Elapsed - lastUpdateTime).TotalSeconds;
                _gameLoopObject.Update(deltaTime);
                lastUpdateTime = _stopwatch.Elapsed;
                Console.WriteLine($"Delta Time: {deltaTime}");
                Console.WriteLine($"Real Elapsed Time: {(float)_stopwatch.Elapsed.TotalSeconds}");
            }
        }
    }
}