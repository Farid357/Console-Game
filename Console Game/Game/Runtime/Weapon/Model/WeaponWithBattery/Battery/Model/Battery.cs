using System;
using ConsoleGame.Tools;

namespace Console_Game
{
    public sealed class Battery : IBattery
    {
        private readonly IBatteryView _view;

        public Battery(IBatteryView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public float Amount { get; private set; }
        
        public bool IsDischarged => Amount == 0;

        public void Charge(float amount)
        {
            Amount += amount.ThrowIfLessOrEqualsToZeroException();
            _view.Visualize(Amount);
        }

        public void Discharge(float amount)
        {
            if (IsDischarged)
                throw new Exception($"Battery is discharged!");

            Amount = Math.Max(0, Amount - amount);
            _view.Visualize(Amount);
            
            if(IsDischarged)
                _view.Discharge();
        }
    }
}