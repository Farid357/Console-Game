using System.Numerics;

namespace ConsoleGame.Tests.Physics
{
    public class DummyCharacter : ICharacter
    {
        public bool IsAlive => true;
        public bool CanShoot { get; }
        public IWeaponData WeaponData { get; }
        public void SwitchWeapon(IWeapon weapon)
        {
            
        }

        public void Move(Vector3 direction)
        {
        }

        public void Shoot()
        {
        }
    }
}