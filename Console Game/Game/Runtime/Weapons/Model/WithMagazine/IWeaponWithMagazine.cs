using System.Threading.Tasks;

namespace Console_Game.Weapons
{
    public interface IWeaponWithMagazine : IWeapon
    {
        IWeaponMagazine Magazine { get; }

        bool CanReload();
        
        Task Reload();
    }
}