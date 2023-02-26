using System;
using System.Threading.Tasks;

namespace Console_Game.Weapons
{
    public sealed class WeaponWithMagazineView : IWeaponWithMagazineView
    {
        private readonly ITimer _reloadTimer;

        public WeaponWithMagazineView(ITimer reloadTimer)
        {
            _reloadTimer = reloadTimer ?? throw new ArgumentNullException(nameof(reloadTimer));
        }

        public bool IsReloading { get; private set; }

        public async Task Reload()
        {
            _reloadTimer.Play();
            IsReloading = true;
            
            while (_reloadTimer.FinishedCountdown == false)
            {
                await Task.Yield();
            }

            IsReloading = false;
        }
    }
}