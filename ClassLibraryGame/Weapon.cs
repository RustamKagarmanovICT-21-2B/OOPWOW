using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassLibraryGame
{
    public class Weapon : ItemBase
    {
        public int Damage { get; private set; }
        public override int MaxQuality => 10;
        public override string Description => $"{Name} (Урон: {Damage}, Качество: {Quality})";

        public Weapon(string name, int baseDamage, int quality = 1) : base(name, quality)
        {
            Damage = baseDamage;
        }

        public override void ApplyImprovement()
        {
            Quality++;
            Damage += 2;
        }
    }
}
