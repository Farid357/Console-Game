using System.Threading.Tasks;
using Console_Game.Weapons;

namespace Console_Game.Tests
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