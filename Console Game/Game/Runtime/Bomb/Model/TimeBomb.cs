using System;

namespace ConsoleGame
{
    public sealed class TimeBomb : IBomb, IGameObject
    {
        private readonly IBomb _bomb;
        private readonly ITimer _blowUpTimer;

        public TimeBomb(ITimer blowUpTimer, IBomb bomb)
        {
            _blowUpTimer = blowUpTimer ?? throw new ArgumentNullException(nameof(blowUpTimer));
            _bomb = bomb ?? throw new ArgumentNullException(nameof(bomb));
        }

        public bool IsAlive => !IsBlownUp;

        public bool IsBlownUp { get; private set; }

        public void BlowUp()
        {
            if (IsBlownUp)
                throw new Exception($"Bomb is blown up!");

            _bomb.BlowUp();
            IsBlownUp = true;
        }

        public void Update(float deltaTime)
        {
            if (!IsAlive)
                throw new Exception($"Bomb is not alive!");

            if (_blowUpTimer.IsEnded && !_bomb.IsBlownUp)
            {
                BlowUp();
            }
        }
    }
}