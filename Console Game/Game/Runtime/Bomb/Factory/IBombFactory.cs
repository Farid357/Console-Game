using System;

namespace ConsoleGame
{
    public interface IBombFactory
    {
        IBomb Create(IReadOnlyTransform transform);
    }

    public sealed class TimeBombFactory : IBombFactory
    {
        private readonly IBombFactory _bombFactory;
        private readonly ITimerFactory _timerFactory;
        private readonly float _secondsToBlowUp;

        public TimeBombFactory(float secondsToBlowUp, ITimerFactory timerFactory, IBombFactory bombFactory)
        {
            _secondsToBlowUp = secondsToBlowUp;
            _timerFactory = timerFactory ?? throw new ArgumentNullException(nameof(timerFactory));
            _bombFactory = bombFactory ?? throw new ArgumentNullException(nameof(bombFactory));
        }

        public IBomb Create(IReadOnlyTransform transform)
        {
            IBomb bomb = _bombFactory.Create(transform);
            ITimer blowUpTimer = _timerFactory.Create(_secondsToBlowUp);
            return new TimeBomb(blowUpTimer, bomb);
        }
    }
}