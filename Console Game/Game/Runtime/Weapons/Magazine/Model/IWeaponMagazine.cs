namespace Console_Game.Weapons
{
    public interface IWeaponMagazine : IReadOnlyWeaponMagazine
    {
        void Take(int bullets);

        void Add(int bullets);
    }

}