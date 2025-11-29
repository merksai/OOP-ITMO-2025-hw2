using System;

namespace RpgInventory
{
    public class NormalWeaponState : IWeaponState
    {
        public string Name => "Обычное";

        public void Equip(Weapon weapon, InventoryContext context)
        {
            weapon.IsEquipped = true;
        }

        public void Use(Weapon weapon, InventoryContext context)
        {
            var random = new Random();
            var roll = random.Next(0, 5);

            if (roll == 0)
            {
                weapon.State = new BrokenWeaponState();
            }
        }
    }
}