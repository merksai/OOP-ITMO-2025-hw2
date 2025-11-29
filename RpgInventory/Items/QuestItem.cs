using System;

namespace RpgInventory
{
    public class QuestItem : IItem
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; }
        public ItemType Type => ItemType.QuestItem;

        public string Description { get; }

        public QuestItem(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Имя не должно быть пустым.", nameof(name));

            Name = name;
            Description = description ?? string.Empty;
        }

        public string Describe()
        {
            return $"{Name} (квестовый предмет) | {Description}";
        }
    }
}