namespace RpgInventory
{
    public interface IUpgradeStrategy
    {
        void Apply(Weapon weapon);
    }
}