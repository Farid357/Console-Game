using System;
using ConsoleGame;
using ConsoleGame.Audio;

namespace Console_Game
{
    public sealed class WeaponBatteryView : IBatteryView
    {
        private readonly ISound _dischargeSound;
        private readonly IEffect _chargeEffect;

        public WeaponBatteryView(ISound dischargeSound, IEffect chargeEffect)
        {
            _dischargeSound = dischargeSound ?? throw new ArgumentNullException(nameof(dischargeSound));
            _chargeEffect = chargeEffect ?? throw new ArgumentNullException(nameof(chargeEffect));
        }

        public void Visualize(float charge)
        {
            if(!_chargeEffect.IsPlaying)
                _chargeEffect.Play();
        }

        public void Discharge()
        {
            _dischargeSound.Play();
            _chargeEffect.Stop();
        }
    }
}