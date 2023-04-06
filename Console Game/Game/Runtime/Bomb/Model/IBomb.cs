namespace ConsoleGame
{
    public interface IBomb
    {
        bool IsBlownUp { get; }
        
        IWeaponActivityView View { get; }
        
        void BlowUp();
    }
}