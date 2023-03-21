namespace Console_Game
{
    public interface IPlayerFactory<in TWeapon, in TWeaponInput> where TWeapon : IWeapon where TWeaponInput : IWeaponInput
    {
        IPlayer Create(TWeaponInput weaponInput, TWeapon weapon);
    }
}