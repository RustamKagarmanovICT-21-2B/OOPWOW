using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGame
{
    public class ResourceSystem
    {
        private readonly Dictionary<string, int> _resources = new Dictionary<string, int>();

        public ResourceSystem()
        {
            // Инициализация ресурсов
            _resources.Add("Золото", 100);
            _resources.Add("Железо", 50);
            _resources.Add("Древесина", 30);
            _resources.Add("Кристаллы", 5);
        }

        public bool HasEnoughResources(string resource, int amount)
        {
            return _resources.ContainsKey(resource) && _resources[resource] >= amount;
        }

        public bool SpendResources(string resource, int amount)
        {
            if (!HasEnoughResources(resource, amount))
                return false;

            _resources[resource] -= amount;
            return true;
        }

        public void AddResources(string resource, int amount)
        {
            if (_resources.ContainsKey(resource))
                _resources[resource] += amount;
            else
                _resources[resource] = amount;
        }

        public void DisplayResources()
        {
            Console.WriteLine("╔══════════════════════════╗");
            Console.WriteLine("║       Ваши ресурсы       ║");
            Console.WriteLine("╠══════════════════════════╣");

            foreach (var resource in _resources)
            {
                Console.WriteLine($"║ {resource.Key,-12} {resource.Value,10} ║");
            }

            Console.WriteLine("╚══════════════════════════╝");
        }
    }
}
