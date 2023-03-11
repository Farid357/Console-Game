namespace Console_Game.Shop
{
    public interface IGood
    {
        string Name { get; }

        int Cost { get; }
        
        void Use();
    }
}