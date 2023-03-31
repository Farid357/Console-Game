using System;
using ConsoleGame.UI;

namespace ConsoleGame
{
    public sealed class InfiniteWeaponView : IInfiniteWeaponView
    {
        private readonly IText _text;
        private readonly IWeaponView _view;

        public InfiniteWeaponView(IText text, IWeaponView view)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }
        
        public bool IsActive => _view.IsActive;

        public void VisualizeBullets()
        {
            _text.Visualize("\u221E");
        }
        
        public void Enable()
        {
            _view.Enable();
        }

        public void Disable()
        {
            _view.Disable();
        }

        public void Shoot()
        {
            _view.Shoot();
        }
    }
}