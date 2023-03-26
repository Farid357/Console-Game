namespace ConsoleGame.Shop
{
    public interface IGood
    {
        string Name { get; }

        int Cost { get; }
        
        void Use();
    }
}