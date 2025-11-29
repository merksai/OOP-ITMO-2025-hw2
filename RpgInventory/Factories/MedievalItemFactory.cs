namespace RpgInventory
{
    public class MedievalItemFactory : IItemFactory
    {
        public Weapon CreateSword(string name, int damage)
        {
            return new WeaponBuilder()
                .WithName(name)
                .WithDamage(damage)
                .Build();
        }

        public Armor CreateArmor(string name, int defense)
        {
            return new Armor(name, defense);
        }

        public Potion CreateHealingPotion(string name, int healAmount)
        {
            return new Potion(name, healAmount);
        }

        public QuestItem CreateQuestItem(string name, string description)
        {
            return new QuestItem(name, description);
        }
    }
}