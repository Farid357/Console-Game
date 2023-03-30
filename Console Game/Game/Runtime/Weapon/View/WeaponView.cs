using ConsoleGame.UI;

namespace ConsoleGame
{
    public sealed class WeaponView : IWeaponView
    {
        private readonly IImage _image;
        private readonly IText _bulletsText;

        public WeaponView(IImage image, IText bulletsText)
        {
            _image = image;
            _bulletsText = bulletsText;
        }

        public void Enable()
        {
            _image.Enable();
            _bulletsText.Enable();
        }

        public void Disable()
        {
            _image.Enable();
            _bulletsText.Disable();
        }
    }
}