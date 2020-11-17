using System;
using Models;
using Data;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repository
{
    public class SalonsRepository : IRepository<Salons>
    {
        CarRentingDbContext context = new CarRentingDbContext();

        public void Delete(string uid)
        {
            var salonToDelete = context.Salons.FirstOrDefault(t => t.SalonId == uid);
            context.Salons.Remove(salonToDelete);
            context.SaveChanges();
        }

        public void Insert(Salons item)
        {
            context.Salons.Add(item);
            context.SaveChanges();
        }

        public IQueryable<Salons> Print()
        {
            return context.Salons.AsQueryable();
        }

        public void Update(string oldid, Salons newitem)
        {
            var oldSalon = context.Salons.FirstOrDefault(t => t.SalonId == oldid);

            oldSalon.PostalCode = newitem.PostalCode;
            oldSalon.City = newitem.City;
            oldSalon.Address = newitem.Address;

            oldSalon.Car.Clear();
            foreach (var item in newitem.Car)
            {
                oldSalon.Car.Add(item);
            }

            context.SaveChanges();
        }
    }
}
