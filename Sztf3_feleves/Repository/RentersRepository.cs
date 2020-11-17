using Models;
using Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repository
{
    public class RentersRepository : IRepository<Renters>
    {
        CarRentingDbContext context = new CarRentingDbContext();

        public void Delete(string uid)
        {
            var renterToDelete = context.Renters.FirstOrDefault(t => t.RenterId == uid);
            context.Renters.Remove(renterToDelete);
            context.SaveChanges();
        }

        public void Insert(Renters item)
        {
            context.Renters.Add(item);
            context.SaveChanges();
        }

        public IQueryable<Renters> Print()
        {
            return context.Renters.AsQueryable();
        }

        public void Update(string oldid, Renters newitem)
        {
            var oldRenter = context.Renters.FirstOrDefault(t => t.RenterId == oldid);

            oldRenter.Name = newitem.Name;
            oldRenter.PostalCode = newitem.PostalCode;
            oldRenter.City = newitem.City;
            oldRenter.Address = newitem.Address;
            oldRenter.Email = newitem.Email;
            oldRenter.PhoneNumber = newitem.PhoneNumber;
            oldRenter.RentedDays = newitem.RentedDays;

            context.SaveChanges();
        }
    }
}
