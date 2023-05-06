namespace ConsoleGame
{
    public interface IReadOnlyCharacter : IEnemy
    {
        bool CanShoot { get; }
        
        IReadOnlyTransform Transform { get; }
        
        IWeaponInventoryItem SelectedWeaponItem { get; }
    }
}