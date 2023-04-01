using ConsoleGame.UI;

namespace ConsoleGame
{
    public interface IWeaponViewFactory
    {
        IWeaponView Create(IImage image);
    }
}