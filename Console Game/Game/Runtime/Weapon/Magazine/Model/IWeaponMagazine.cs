namespace ConsoleGame.Weapons
{
    public interface IWeaponMagazine : IReadOnlyWeaponMagazine
    {
        void Take(int bullets);

        void Add(int bullets);
        
        void Fill();
    }
}