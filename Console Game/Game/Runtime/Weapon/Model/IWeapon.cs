namespace ConsoleGame
{
    public interface IWeapon
    {
        bool CanShoot { get; }
        
        IWeaponData Data { get; }

        void Shoot();
    }

    public interface IThrowingWeapon
    {
        void Throw();
    }
}