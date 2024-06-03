using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGame
{
    public class Player
    {
        public string Name { get; set; }
        public List<Item> Inventory { get; set; }

        public Player(string name)
        {
            Name = name;
            Inventory = new List<Item>();
        }

        public void ShowInventory()
        {
            foreach (var item in Inventory)
            {
                Console.WriteLine(item);
            }
        }
    }
}
