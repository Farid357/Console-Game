namespace Console_Game
{
    public interface ITimer
    {
        float Time { get; }
        
        bool IsEnded { get; }
        
        bool IsActive { get; }

        void Play();
    }
}