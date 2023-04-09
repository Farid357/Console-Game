namespace ConsoleGame.Bonus
{
    public interface IBonusFactory
    {
        IBonus Create(ITransform transform);
    }
}