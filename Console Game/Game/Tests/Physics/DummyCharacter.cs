using System.Numerics;

namespace ConsoleGame.Tests.Physics
{
    public sealed class DummyCharacter : ICharacter
    {
        public bool IsAlive => Health.IsAlive;

        public bool CanShoot => false;
        
        public IHealth Health { get; } = new Health(1000);
        
        public IReadOnlyTransform Transform { get; } = new Transform();

        public IWeaponInventoryItem SelectedWeaponItem { get; } =
            new WeaponInventoryItem(new DummyInventoryItem(), new DummyWeapon(), new WeaponParts(false));


        public void Move(Vector3 direction)
        {
        }

        public void Shoot()
        {
        }
    }
}