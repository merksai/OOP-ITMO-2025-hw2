using System;

namespace RpgInventory
{
    public class BrokenWeaponState : IWeaponState
    {
        public string Name => "Сломанное";

        public void Equip(Weapon weapon, InventoryContext context)
        {
            throw new InvalidOperationException("Нельзя экипировать сломанное оружие.");
        }

        public void Use(Weapon weapon, InventoryContext context) {}
    }
}