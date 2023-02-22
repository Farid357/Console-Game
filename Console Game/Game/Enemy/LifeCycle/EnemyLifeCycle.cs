using System;

namespace Console_Game
{
    public sealed class EnemyLifeCycle : IEnemyLifeCycle
    {
        private readonly IEnemyLifeCyclePeriod[] _periods;
        private bool _isStopped;
        private int _periodIndex;

        public EnemyLifeCycle(IEnemyLifeCyclePeriod[] periods)
        {
            _periods = periods ?? throw new ArgumentNullException(nameof(periods));
            CurrentPeriod = _periods[0];
        }

        public bool IsCompleted => _periodIndex == _periods.Length;
        
        public IEnemyLifeCyclePeriod CurrentPeriod { get; private set; }

        public void Continue() => _isStopped = false;

        public void Restart()
        {
            CurrentPeriod = _periods[0];
            _periodIndex = 0;
        }

        public void Stop()
        {
            if (_isStopped)
                throw new InvalidOperationException($"Already stopped!");

            _isStopped = true;
        }

        public void Update(float deltaTime)
        {
            if (_isStopped)
                return;

            if (CurrentPeriod.IsCompleted)
            {
                _periodIndex++;

                if (_periodIndex < _periods.Length)
                    CurrentPeriod = _periods[_periodIndex];
            }
        }
    }
}