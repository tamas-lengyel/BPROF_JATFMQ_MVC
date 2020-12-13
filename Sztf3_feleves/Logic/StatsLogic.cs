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
            var q1 = (from x in carrepo.Print().ToList()
                      join y in salonrepo.Print().ToList() on x.SalonId equals y.SalonId
                      where y.City == "Budapest"
                      select x).Average(a => a.PricePerDay);

            return q1;
        }

        public IEnumerable<NumberOfCarsinEachsalon> NumberOfCarsInEachSalon()
        {

            var q = from x in salonrepo.Print().ToList()
                    select new NumberOfCarsinEachsalon
                    {
                        Address = x.Address,
                        CountedCars = x.Car.Count(a => a.Available == true)
                    };
            

            return q;
        }

        public IEnumerable<Renters> PrintOnlyRentersThatRentedAudis()
        {
            var q = from x in renterrepo.Print().ToList()
                    join y in carrepo.Print().ToList() on x.CarId equals y.CarId
                    where y.Make == "Audi"
                    select x;

            return q.ToList();
        }
    }
}
