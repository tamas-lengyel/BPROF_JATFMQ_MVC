using System;
using Models;
using Repository;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Logic
{
    public class SalonsLogic
    {
        IRepository<Salons> salonrepo;

        public SalonsLogic(IRepository<Salons> salonrepo)
        {
            this.salonrepo = salonrepo;
        }

        public void DeleteSalon(string salonid)
        {
            salonrepo.Delete(salonid);
        }

        public void InsertSalon(Salons salon)
        {
            salonrepo.Insert(salon);
        }

        public IQueryable<Salons> PrintSalons()
        {
            return salonrepo.Print();
        }

        public void UpdateSalon(string salonid, Salons salon)
        {
            salonrepo.Update(salonid, salon);
        }
    }
}
