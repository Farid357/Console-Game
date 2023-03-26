using System.Threading.Tasks;

namespace ConsoleGame.Weapons
{
    public interface IWeaponWithMagazineView
    {
        bool IsReloading { get; }
        
        Task Reload();
    }
}