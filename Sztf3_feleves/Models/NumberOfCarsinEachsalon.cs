using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class NumberOfCarsinEachsalon
    {
        public string Address { get; set; }
        public int CountedCars { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is NumberOfCarsinEachsalon)
            {
                NumberOfCarsinEachsalon num = obj as NumberOfCarsinEachsalon;
                return this.Address == num.Address &&
                this.CountedCars == num.CountedCars;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}
