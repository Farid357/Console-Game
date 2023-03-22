namespace Console_Game.Weapons
{
    public interface IReadOnlyWeaponMagazine
    {
        int Bullets { get; }

        int MaxBullets { get; }

        bool IsEmpty { get; }

        bool CanAdd(int bullets);
    }
}