using System.Threading.Tasks;
using ConsoleGame.Weapons;

namespace ConsoleGame.Tests
{
    public class DummyWeaponWithMagazineView : IWeaponWithMagazineView
    {
        public bool IsReloading => false;
        
        public async Task Reload()
        {
            await Task.Yield();
        }
    }
}