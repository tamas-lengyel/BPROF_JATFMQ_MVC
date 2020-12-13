using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Stats
    {
        public double AvgPriceOfCarsFromBudapest { get; set; }

        public IEnumerable<NumberOfCarsinEachsalon> CountedCars { get; set; }

        public IEnumerable<Renters> RentedAudis { get; set; }
    }
}
