using System;
using Models;
using Repository;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Logic
{
    public class CarsLogic
    {
        IRepository<Cars> carrepo;

        public CarsLogic(IRepository<Cars> carrepo)
        {
            this.carrepo = carrepo;
        }

        public void DeleteCar(string carid)
        {
            carrepo.Delete(carid);
        }

        public void InsertCar(Cars car)
        {
            carrepo.Insert(car);
        }

        public IQueryable<Cars> PrintCars()
        {
            return carrepo.Print();
        }

        public void UpdateCar(string carid, Cars car)
        {
            carrepo.Update(carid, car);
        }
    }
}
