namespace Console_Game
{
    public interface ITimer
    {
        bool IsEnded { get; }
        
        bool IsActive { get; }

        void Play();
    }
}