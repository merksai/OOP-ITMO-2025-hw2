namespace RpgInventory
{
    public interface IWeaponState
    {
        string Name { get; }
        void Equip(Weapon weapon, InventoryContext context);
        void Use(Weapon weapon, InventoryContext context);
    }
}
