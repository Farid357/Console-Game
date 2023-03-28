namespace ConsoleGame
{
    public interface IBomb
    {
        bool IsBlownUp { get; }
        
        void BlowUp();
    }
}