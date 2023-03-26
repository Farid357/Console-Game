namespace ConsoleGame
{
    public interface IWeapon
    {
        bool CanShoot { get; }

        void Shoot();
    }
}