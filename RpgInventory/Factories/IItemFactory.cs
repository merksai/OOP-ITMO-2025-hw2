namespace RpgInventory
{
    public interface IItemFactory
    {
        Weapon CreateSword(string name, int damage);
        Armor CreateArmor(string name, int defense);
        Potion CreateHealingPotion(string name, int healAmount);
        QuestItem CreateQuestItem(string name, string description);
    }
}
