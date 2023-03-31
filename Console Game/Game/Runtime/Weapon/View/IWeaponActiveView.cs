namespace ConsoleGame
{
    public interface IWeaponActiveView
    {
        bool IsActive { get; }
        
        void Enable();
        
        void Disable();
    }
}