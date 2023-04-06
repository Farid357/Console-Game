using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public class NullWeaponMagazine : IWeaponMagazine
    {
        public int Bullets { get; }
        
        public int MaxBullets { get; }
        
        public void Take(int bullets)
        {
            
        }

        public void Add(int bullets)
        {
        }

        public void Fill()
        {
            
        }
    }
}