using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGame
{
    public interface IForgingStrategy
    {
        bool TryForge(Item item, int blacksmithSkill);
    }
}
