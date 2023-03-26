using System;
using System.Threading.Tasks;

namespace ConsoleGame.Weapons
{
    public sealed class WeaponWithMagazineView : IWeaponWithMagazineView
    {
        public bool IsReloading { get; private set; }

        public async Task Reload()
        {
            IsReloading = true;
            await Task.Delay(TimeSpan.FromSeconds(1.2f));
            IsReloading = false;
        }
    }
}