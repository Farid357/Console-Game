using System.Drawing;
using System.Numerics;
using ConsoleGame.UI;
using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public sealed class WeaponMagazineViewFactory
    {
        private readonly ITextFactory _textFactory;
        
        public IWeaponMagazineView Create()
        {
            ITransform transform = new Transform(new Vector2(150, 200));
            IText text = _textFactory.Create(transform, new Font("Arial", 18), Color.Blue);
            return new WeaponMagazineView(text);
        }
    }
}