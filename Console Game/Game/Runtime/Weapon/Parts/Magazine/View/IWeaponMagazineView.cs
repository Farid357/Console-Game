using System.Threading.Tasks;

namespace ConsoleGame.Weapons
{
    public interface IWeaponMagazineView
    {
        void Visualize(int bullets, int maxBullets);
        
        Task Fill();
    }
}