using System;
using ConsoleGame.GameLoop;

namespace ConsoleGame
{
    public interface IBombFactory
    {
        IBomb Create(IReadOnlyTransform transform);
    }

    public sealed class TimeBombFactory : IBombFactory
    {
        private readonly IBombFactory _bombFactory;
        private readonly IGameLoopObjectsGroup _gameLoop;
        private readonly float _secondsToBlowUp;

        public TimeBombFactory(IGameLoopObjectsGroup gameLoop, float secondsToBlowUp, IBombFactory bombFactory)
        {
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
            _secondsToBlowUp = secondsToBlowUp;
            _bombFactory = bombFactory ?? throw new ArgumentNullException(nameof(bombFactory));
        }

        public IBomb Create(IReadOnlyTransform transform)
        {
            IBomb bomb = _bombFactory.Create(transform);
            var blowUpTimer = new Timer(_secondsToBlowUp);
            _gameLoop.Add(blowUpTimer);
            return new TimeBomb(blowUpTimer, bomb);
        }
    }
}