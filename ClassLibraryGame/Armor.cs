using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassLibraryGame
{
    public class Armor : ItemBase
    {
        public int Defense { get; private set; }
        public override int MaxQuality => 8;
        public override string Description => $"{Name} (Защита: {Defense}, Качество: {Quality})";

        public Armor(string name, int baseDefense, int quality = 1) : base(name, quality)
        {
            Defense = baseDefense;
        }

        public override void ApplyImprovement()
        {
            Quality++;
            Defense += 3;
        }
    }
}
