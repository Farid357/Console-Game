namespace Console_Game.Weapons
{
    public interface IBullet
    {
        bool IsDestroyed { get; }
        
        void Throw();

        void Destroy();
    }
}