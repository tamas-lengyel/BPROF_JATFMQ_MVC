using System;
using Models;
using Data;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repository
{
    public class CarsRepository : IRepository<Cars>
    {
        CarRentingDbContext context = new CarRentingDbContext();

        public void Delete(string uid)
        {
            var carToDelete = context.Cars.FirstOrDefault(t => t.CarId == uid);
            context.Cars.Remove(carToDelete);
            context.SaveChanges();
        }

        public void Insert(Cars item)
        {
            context.Cars.Add(item);
            context.SaveChanges();
        }

        public IQueryable<Cars> Print()
        {
            return context.Cars.AsQueryable();
        }

        public void Update(string oldid, Cars newitem)
        {
            var oldCar = context.Cars.FirstOrDefault(t => t.CarId == oldid);

            oldCar.Make = newitem.Make;
            oldCar.Model = newitem.Model;
            oldCar.ModelYear = newitem.ModelYear;
            oldCar.BodyType = newitem.BodyType;
            oldCar.CombFuelEco = newitem.CombFuelEco;
            oldCar.Available = newitem.Available;
            oldCar.PricePerDay = newitem.PricePerDay;

            context.SaveChanges();
        }
    }
}
