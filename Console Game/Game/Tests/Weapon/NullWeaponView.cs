namespace ConsoleGame.Tests
{
    public class NullWeaponView : IWeaponView
    {
        public bool IsActive { get; private set; } = true;
        
        public void Enable()
        {
            IsActive = true;
        }

        public void Disable()
        {
            IsActive = false;
        }

        public void Shoot()
        {
            
        }
    }
}