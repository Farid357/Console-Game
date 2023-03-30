using System.Threading.Tasks;
using ConsoleGame.Weapons;

namespace ConsoleGame.Tests
{
    public class DummyWeaponWithReloadingView : IWeaponWithReloadingView
    {
        public bool IsReloading => false;
        
        public async Task Reload()
        {
            await Task.Yield();
        }
    }
}