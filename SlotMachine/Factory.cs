using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    internal class Factory
    {
        internal Symbol SymbolA = new Symbol('A', 0.4f, 45);
        internal Symbol SymbolB = new Symbol('B', 0.6f, 35);
        internal Symbol SymbolP = new Symbol('P', 0.8f, 15);
        internal Symbol SymbolW = new Symbol('*', 0, 5);
    }
}
