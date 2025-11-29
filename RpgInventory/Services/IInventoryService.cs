namespace RpgInventory
{
    public interface IInventoryService
    {
        void UseItem(IItem item, InventoryContext context);
        void EquipItem(IItem item, InventoryContext context);
    }
}
