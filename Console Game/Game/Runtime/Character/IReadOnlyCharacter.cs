namespace ConsoleGame
{
    public interface IReadOnlyCharacter : IReadOnlyGameObject
    {
        bool CanShoot { get; }
        
        IHealth Health { get; }
        
        IReadOnlyTransform Transform { get; }
        
        IWeaponInventoryItem SelectedWeaponItem { get; }
    }
}