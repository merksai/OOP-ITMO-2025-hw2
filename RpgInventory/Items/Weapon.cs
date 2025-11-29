using System;

namespace RpgInventory
{
    public class Weapon : IItem, IEquippable, IUpgradeable, IUsable
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; }
        public ItemType Type => ItemType.Weapon;

        public int Damage { get; set; }

        public bool IsEquipped { get; internal set; }

        public IWeaponState State { get; set; }

        public Weapon(string name, int damage)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Имя не должно быть пустым.", nameof(name));
            if (damage <= 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            Name = name;
            Damage = damage;
            State = new NormalWeaponState();
        }

        public void Equip(InventoryContext context)
        {
            State.Equip(this, context);
        }

        public void Unequip(InventoryContext context)
        {
            IsEquipped = false;
        }

        public void Upgrade(IUpgradeStrategy strategy)
        {
            strategy?.Apply(this);
        }

        public void Use(InventoryContext context)
        {
            State.Use(this, context);
        }

        public string Describe()
        {
            return $"{Name} (оружие) | Урон: {Damage}, Состояние: {State.Name}, Экипировано: {IsEquipped}";
        }
    }
}