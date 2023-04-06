using System;
using System.Numerics;

namespace ConsoleGame.Weapons
{
    public sealed class LaserWeaponView : ILaserView
    {
        private readonly IWeaponActivityView _view;

        public LaserWeaponView(IWeaponActivityView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }
        
        public bool IsActive => _view.IsActive;

        public void ShowLaser(Vector3 origin, Vector3 direction)
        {
            Console.WriteLine($"Laser from origin: {origin}, to direction: {direction}");
        }


        public void Enable()
        {
            _view.Enable();
        }

        public void Disable()
        {
            _view.Disable();
        }
    }
}