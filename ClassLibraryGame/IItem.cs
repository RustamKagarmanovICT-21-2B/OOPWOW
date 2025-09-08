using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGame
{
    internal interface IItem
    {
        string Name { get; }
        int Quality { get; set; }
        int MaxQuality { get; }
        void ApplyImprovement();
    }
}
