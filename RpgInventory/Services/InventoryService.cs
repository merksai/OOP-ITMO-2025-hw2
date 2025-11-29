using System;

namespace RpgInventory
{
    public class InventoryService : IInventoryService
    {
        public void UseItem(IItem item, InventoryContext context)
        {
            if (item is IUsable usable)
            {
                usable.Use(context);
            }
            else
            {
                throw new InvalidOperationException($"Предмет '{item.Name}' нельзя использовать.");
            }
        }

        public void EquipItem(IItem item, InventoryContext context)
        {
            if (item is IEquippable equippable)
            {
                equippable.Equip(context);
            }
            else
            {
                throw new InvalidOperationException($"Предмет '{item.Name}' нельзя экипировать.");
            }
        }
    }
}