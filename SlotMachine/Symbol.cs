using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    internal class Symbol
    {
        internal char Name { get; set; }

        internal float Coefficient { get; set; }

        //[Range(1, 100, ErrorMessage = "Probability value must be between 1 and 100")]
        internal int Probability { get; set; }

        internal Symbol(char name, float coefficient, int probability)
        {
            this.Name = name;
            this.Coefficient = coefficient;
            this.Probability = probability;
        }
    }
}
