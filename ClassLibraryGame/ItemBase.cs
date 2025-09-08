using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGame
{
    public abstract class ItemBase : IItem
    {
        public string Name { get; protected set; }
        public int Quality { get; set; }
        public abstract int MaxQuality { get; }
        public abstract string Description { get; }

        protected ItemBase(string name, int quality = 1)
        {
            Name = name;
            Quality = quality;
        }

        public abstract void ApplyImprovement();

        public override string ToString() => Description;
    }
}
