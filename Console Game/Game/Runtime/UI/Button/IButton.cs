namespace Console_Game.Shop
{
    public interface IButton
    {
        void Press();
    }

    public sealed class Button : IButton
    {
        public void Press()
        {
        }
    }
}