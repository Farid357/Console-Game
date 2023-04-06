using System;
using ConsoleGame;
using ConsoleGame.Tools;

namespace Console_Game
{
    public sealed class SelfDischargingBattery : IBattery, IGameLoopObject
    {
        private readonly IBattery _battery;
        private readonly float _dischargingSpeed;
        
        public SelfDischargingBattery(IBattery battery, float dischargingSpeed)
        {
            _battery = battery ?? throw new ArgumentNullException(nameof(battery));
            _dischargingSpeed = dischargingSpeed.ThrowIfLessOrEqualsToZeroException();
        }

        public float Amount => _battery.Amount;

        public bool IsDischarged => _battery.IsDischarged;

        public void Charge(float amount)
        {
            _battery.Charge(amount);
        }

        public void Discharge(float amount)
        {
            _battery.Discharge(amount);
        }

        public void Update(float deltaTime)
        {
            if(_battery.IsDischarged)
                return;
            
            _battery.Discharge(_dischargingSpeed * deltaTime);
        }
    }
}