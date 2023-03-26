namespace ConsoleGame.Weapons
{
    public interface IReadOnlyWeaponMagazine
    {
        int Bullets { get; }
        
        int MaxBullets { get; }

    }
}