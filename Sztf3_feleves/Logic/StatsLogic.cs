using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Logic
{
    public class StatsLogic
    {
        IRepository<Salons> salonrepo;
        IRepository<Cars> carrepo;
        IRepository<Renters> renterrepo;

        public StatsLogic(IRepository<Salons> salonrepo, IRepository<Cars> carrepo, IRepository<Renters> renterrepo)
        {
            this.salonrepo = salonrepo;
            this.carrepo = carrepo;
            this.renterrepo = renterrepo;
        }

        public double AvgPriceOfCarsFromBudapest()
        {
            double avgPrice = 0;
            var r = carrepo.Print().ToList();
            if (r.Count() != 0)
            {
                avgPrice = (from x in carrepo.Print().ToList()
                                join y in salonrepo.Print().ToList() on x.SalonId equals y.SalonId
                                where y.City == "Budapest"
                                select x).Average(a => a.PricePerDay);
            }
            else
            {
                avgPrice = -1;
            }
            

            return avgPrice;
        }

        public IEnumerable<NumberOfCarsinEachsalon> NumberOfCarsInEachSalon()
        {
            var salonsWithCars = from x in carrepo.Print().ToList()
                                 group x by x.SalonId into g
                                 join y in salonrepo.Print().ToList() on g.Key equals y.SalonId
                                 select new NumberOfCarsinEachsalon
                                 {
                                    Address = y.Address,
                                    CountedCars = g.Count()
                                 };

            return salonsWithCars;
        }

        public IEnumerable<Renters> PrintOnlyRentersThatRentedAudis()
        {
            var rentedAudis = from x in renterrepo.Print().ToList()
                              join y in carrepo.Print().ToList() on x.CarId equals y.CarId
                              where y.Make == "Audi"
                              select x;

            return rentedAudis.ToList();
        }
    }
}
