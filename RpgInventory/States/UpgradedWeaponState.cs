namespace RpgInventory
{
    public class UpgradedWeaponState : IWeaponState
    {
        public string Name => "Улучшенное";

        public void Equip(Weapon weapon, InventoryContext context)
        {
            weapon.IsEquipped = true;
        }

        public void Use(Weapon weapon, InventoryContext context) {}
    }
}