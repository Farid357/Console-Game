namespace ConsoleGame
{
    public interface IWeapon
    {
        bool CanShoot { get; }
        
        IWeaponActivityView View { get; }
        
        void Shoot();
    }
}