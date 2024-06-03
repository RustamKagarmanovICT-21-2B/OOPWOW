using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGame
{
    public class Item
    {
        public string Name { get; set; }
        public int ItemId { get; set; }
        public int Quality { get; set; }

        public Item(string name, int quality, int itemId)
        {
            Name = name;
            Quality = quality;
            ItemId = itemId;
        }
        public Item(string name, int itemId)
        {
            Name = name;
            ItemId = itemId;
        }



        // Переопределение ToString для описания объекта
        public override string ToString()
        {
            return $"Item: {Name}, ID: {ItemId}";
        }

        // Переопределение Equals для сравнения Item
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            Item other = (Item)obj;
            return this.ItemId == other.ItemId;
        }

        // Переопределение GetHashCode для генерации хэш кода, на основе id
        public override int GetHashCode()
        {
            return ItemId.GetHashCode();
        }
    }

}
