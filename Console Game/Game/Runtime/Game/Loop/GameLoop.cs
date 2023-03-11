using System;
using System.Threading.Tasks;
using Console_Game.Tools;

namespace Console_Game.Loop
{
    public sealed class GameLoop : IGameLoop
    {
        private readonly IReadOnlyGameTimer _gameTimer;
        private readonly IFps _fps;
        private readonly IReadOnlyGamePause _gamePause;
        private readonly IGameLoopObjects _gameLoopObjects = new GameLoopObjects();
        
        private readonly float _timeStep;
        private float _lastUpdateTime;
        private float _deltaTime;

        public GameLoop(IReadOnlyGameTimer gameTimer, float timeStep, IReadOnlyGamePause gamePause)
        {
            _gameTimer = gameTimer ?? throw new ArgumentNullException(nameof(gameTimer));
            _gamePause = gamePause ?? throw new ArgumentNullException(nameof(gamePause));
            _timeStep = timeStep.ThrowIfLessOrEqualsToZeroException();
        }

        public IGroup<IGameLoopObject> Objects => _gameLoopObjects;

        public async void Start()
        {
            if (_gameTimer.IsActive == false)
                throw new InvalidOperationException($"You have to play game timer!");
            
            while (true)
            {
                if (_gamePause.IsActive)
                    continue;
                
                _deltaTime = _gameTimer.ElapsedMilliseconds - _lastUpdateTime;
            //    var fpsCount = _fps.Calculate(_deltaTime, _gameTimer.ElapsedMilliseconds);

                for (var frame = 0; frame < 30; frame++)
                {
                    _gameLoopObjects.Update(_lastUpdateTime + _timeStep * (frame + 1));
                    Console.WriteLine();
                    Console.WriteLine(_lastUpdateTime + _timeStep * (frame + 1));
                }

                _lastUpdateTime += _timeStep * 30;
                await Task.Yield();
            }
        }
    }
}