namespace Console_Game.Weapons
{
    public interface IWeaponWithMagazine : IWeapon
    {
        IWeaponMagazine Magazine { get; }

        bool CanReload();
        
        void Reload();
    }
}