using System;

namespace RpgInventory
{
    public class Armor : IItem, IEquippable
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; }
        public ItemType Type => ItemType.Armor;

        public int Defense { get; }

        public bool IsEquipped { get; private set; }

        public Armor(string name, int defense)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Имя не должно быть пустым.", nameof(name));
            if (defense <= 0)
                throw new ArgumentOutOfRangeException(nameof(defense));

            Name = name;
            Defense = defense;
        }

        public void Equip(InventoryContext context)
        {
            IsEquipped = true;
        }

        public void Unequip(InventoryContext context)
        {
            IsEquipped = false;
        }

        public string Describe()
        {
            return $"{Name} (броня) | Защита: {Defense}, Экипировано: {IsEquipped}";
        }
    }
}
