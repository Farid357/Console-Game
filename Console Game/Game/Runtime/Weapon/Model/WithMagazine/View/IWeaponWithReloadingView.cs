using System.Threading.Tasks;

namespace ConsoleGame.Weapons
{
    public interface IWeaponWithReloadingView
    {
        bool IsReloading { get; }

        Task Reload();
    }
}