using System;
using ConsoleGame.Loop;

namespace ConsoleGame
{
    public sealed class TimerFactory : ITimerFactory
    {
        private readonly IGameLoopObjects _gameLoop;

        public TimerFactory(IGameLoopObjects gameLoop)
        {
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
        }

        public ITimer Create(float cooldown)
        {
            var timer = new Timer(cooldown);
            _gameLoop.Add(timer);
            return timer;
        }
    }
}