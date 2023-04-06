using System.Threading.Tasks;
using ConsoleGame.Weapons;

namespace ConsoleGame.Tests
{
    public sealed class DummyMagazineView : IWeaponMagazineView
    {
        public void Visualize(int bullets, int maxBullets)
        {
            
        }

        public Task Fill()
        {
            return Task.CompletedTask;
        }
    }
}