namespace Console_Game.Weapons
{
    public interface IWeaponMagazine
    {
        int Bullets { get; }

        int MaxBullets { get; }

        bool IsEmpty { get; }

        void Take(int bullets);

        void Add(int bullets);
    }
}