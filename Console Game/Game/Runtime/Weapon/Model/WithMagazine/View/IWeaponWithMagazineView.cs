using System.Threading.Tasks;

namespace Console_Game.Weapons
{
    public interface IWeaponWithMagazineView
    {
        bool IsReloading { get; }
        
        Task Reload();
    }
}