﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    internal class Calculations
    {
        private static Factory factory = new Factory();

        Symbol apple = factory.SymbolA;
        Symbol banana = factory.SymbolB;
        Symbol pineapple = factory.SymbolP;
        Symbol wildcard = factory.SymbolW;

        internal float SumSymbolsCoefficient(Symbol first, Symbol second, Symbol third, List<char> row)
        {
            var sumOfElements = 0f;

            //var apple = factory.SymbolA;
            //var banana = factory.SymbolB;
            //var pineapple = factory.SymbolP;
            //var wildcard = factory.SymbolW;

            var matchAll = first.Name == second.Name && second.Name == third.Name;
            if (matchAll)
            {
                return (first.Coefficient * 3);
            }

            var f2s = first.Name.CompareTo(second.Name);
            var s2t = second.Name.CompareTo(third.Name);
            var f2t = first.Name.CompareTo(third.Name);

            var zeroCombination = !row.Contains(wildcard.Name) &&
                (!row.Contains(apple.Name) || !row.Contains(banana.Name) || !row.Contains(pineapple.Name));

            if ((f2s != 0 && s2t != 0 && f2t != 0) || zeroCombination)
            {
                return sumOfElements;
            }

            sumOfElements = first.Coefficient + second.Coefficient + third.Coefficient;

            return sumOfElements;
        }

        internal Symbol CalcSymbolsProbability()
        {
            Random random = new Random();
            int randomNum = random.Next(1, 101);

            if (randomNum <= apple.Probability)
            {
                return apple;
            }
            else if (randomNum <= apple.Probability + banana.Probability)
            {
                return banana;
            }
            else if (randomNum <= apple.Probability + banana.Probability + pineapple.Probability)
            {
                return pineapple;
            }
            else
            {
                return wildcard;
            }
        }
    }
}
