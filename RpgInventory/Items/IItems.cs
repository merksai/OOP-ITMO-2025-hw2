using System;

namespace RpgInventory
{
    public interface IItem
    {
        Guid Id { get; }
        string Name { get; }
        ItemType Type { get; }

        string Describe();
    }

    public interface IUsable
    {
        void Use(InventoryContext context);
    }

    public interface IEquippable
    {
        bool IsEquipped { get; }
        void Equip(InventoryContext context);
        void Unequip(InventoryContext context);
    }

    public interface IUpgradeable
    {
        void Upgrade(IUpgradeStrategy strategy);
    }
}