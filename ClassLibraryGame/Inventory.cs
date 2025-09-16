using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGame
{
    public class Inventory
    {
        private readonly List<ItemBase> _items = new List<ItemBase>();
        private readonly int _capacity;

        public event Action<ItemBase> OnItemAdded;
        public event Action<ItemBase> OnItemRemoved;

        public Inventory(int capacity = 20)
        {
            _capacity = capacity;
        }

        public bool AddItem(ItemBase item)
        {
            if (_items.Count >= _capacity)
            {
                ConsoleHelper.WriteError("Инвентарь переполнен!");
                return false;
            }

            _items.Add(item);
            OnItemAdded?.Invoke(item);
            ConsoleHelper.WriteSuccess($"Добавлен: {item.Name}");
            return true;
        }

        public bool RemoveItem(ItemBase item)
        {
            if (_items.Remove(item))
            {
                OnItemRemoved?.Invoke(item);
                return true;
            }
            return false;
        }

        public void DisplayInventory()
        {
            if (_items.Count == 0)
            {
                ConsoleHelper.WriteWarning("Инвентарь пуст!");
                return;
            }

            ConsoleHelper.WriteHeader("ИНВЕНТАРЬ");

            var groupedItems = _items.GroupBy(i => i.Name)
                                    .OrderBy(g => g.Key);

            foreach (var group in groupedItems)
            {
                int count = group.Count();
                ItemBase sample = group.First();

                ConsoleHelper.WriteItem(sample);
                if (count > 1)
                {
                    Console.WriteLine($"  Количество: {count}");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Свободно мест: {_capacity - _items.Count}/{_capacity}");
        }

        public ItemBase FindItem(string name)
        {
            return _items.FirstOrDefault(i =>
                i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
