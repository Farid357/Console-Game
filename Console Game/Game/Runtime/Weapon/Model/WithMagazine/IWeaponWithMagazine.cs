using System.Threading.Tasks;

namespace ConsoleGame.Weapons
{
    public interface IWeaponWithMagazine : IWeapon
    {
        IWeaponMagazine Magazine { get; }

        bool CanReload();
        
        Task Reload();
    }
}