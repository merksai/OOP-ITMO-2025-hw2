using System;
using System.Collections.Generic;
using System.Linq;

namespace RpgInventory
{
    public class Inventory
    {
        private readonly List<IItem> _items = new();

        public IReadOnlyCollection<IItem> Items => _items.AsReadOnly();

        public void AddItem(IItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _items.Add(item);
        }

        public void RemoveItem(IItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _items.Remove(item);
        }

        public string Describe()
        {
            if (!_items.Any())
                return "Инвентарь пуст.";

            return string.Join(Environment.NewLine, _items.Select(i => i.Describe()));
        }
    }
}
