using System;

namespace RpgInventory
{
    public class Potion : IItem, IUsable
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; }
        public ItemType Type => ItemType.Potion;

        public int HealAmount { get; }
        public bool IsConsumed { get; private set; }

        public Potion(string name, int healAmount)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Имя не должно быть пустым.", nameof(name));
            if (healAmount <= 0)
                throw new ArgumentOutOfRangeException(nameof(healAmount));

            Name = name;
            HealAmount = healAmount;
        }

        public void Use(InventoryContext context)
        {
            if (IsConsumed) return;

            context.PlayerStats.Heal(HealAmount);
            context.Inventory.RemoveItem(this);
            IsConsumed = true;
        }

        public string Describe()
        {
            return $"{Name} (зелье) | Восстановление: {HealAmount}, Использовано: {IsConsumed}";
        }
    }
}