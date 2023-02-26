namespace Console_Game
{
    public interface IWeapon
    {
        bool CanShoot { get; }

        void Shoot();
    }
}