using System;
using System.Diagnostics;
using System.Threading.Tasks;
using ConsoleGame.Tools;

namespace ConsoleGame.Loop
{
    public sealed class GameLoop : IGameLoop
    {
        private readonly Stopwatch _stopwatch;
        private readonly IReadOnlyGamePause _gamePause;
        private readonly IGameLoopObjects _gameObjects;
        
        private readonly float _timeStep;
        private float _lastUpdateTime;

        public GameLoop(float timeStep, IReadOnlyGamePause gamePause)
        {
            _gamePause = gamePause ?? throw new ArgumentNullException(nameof(gamePause));
            _timeStep = timeStep.ThrowIfLessOrEqualsToZeroException();
            _gameObjects = new GameLoopObjects();
            _stopwatch = new Stopwatch();
        }

        public IGameLoopObjectsGroup Objects => _gameObjects;

        public async void Start()
        {
            if (_stopwatch.IsRunning == false)
                throw new InvalidOperationException($"You have to play game timer!");
            
            _stopwatch.Start();
            
            while (true)
            {
                if (_gamePause.IsActive)
                    continue;
                
              //  _deltaTime = _gameTimer.ElapsedMilliseconds - _lastUpdateTime;
            //    var fpsCount = _fps.Calculate(_deltaTime, _gameTimer.ElapsedMilliseconds);

                for (var frame = 0; frame < 30; frame++)
                {
                    _gameObjects.Update(_lastUpdateTime + _timeStep * (frame + 1));
                    Console.WriteLine(_lastUpdateTime + _timeStep * (frame + 1));
                }

                _lastUpdateTime += _timeStep * 30;
                await Task.Yield();
            }
        }
    }
}