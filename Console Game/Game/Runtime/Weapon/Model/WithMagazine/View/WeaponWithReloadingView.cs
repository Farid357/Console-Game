using System;
using System.Threading.Tasks;

namespace ConsoleGame.Weapons
{
    public sealed class WeaponWithReloadingView : IWeaponWithReloadingView
    {
        public bool IsReloading { get; private set; }

        public void UpdateReloadingTime()
        {
            
        }

        public async Task Reload()
        {
            IsReloading = true;
            await Task.Delay(TimeSpan.FromSeconds(1.2f));
            IsReloading = false;
        }
    }
}