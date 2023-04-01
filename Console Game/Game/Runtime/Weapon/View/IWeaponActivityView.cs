namespace ConsoleGame
{
    public interface IWeaponActivityView
    {
        bool IsActive { get; }
        
        void Enable();
        
        void Disable();
    }
}