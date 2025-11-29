using System;

namespace RpgInventory
{
    public class InventoryContext
    {
        public Inventory Inventory { get; }
        public PlayerStats PlayerStats { get; }

        public InventoryContext(Inventory inventory, PlayerStats playerStats)
        {
            Inventory = inventory ?? throw new ArgumentNullException(nameof(inventory));
            PlayerStats = playerStats ?? throw new ArgumentNullException(nameof(playerStats));
        }
    }
}