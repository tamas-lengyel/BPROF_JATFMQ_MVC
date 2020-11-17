using System;
using Models;
using Repository;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Logic
{
    public class RentersLogic
    {
        IRepository<Renters> renterrepo;

        public RentersLogic(IRepository<Renters> renterrepo)
        {
            this.renterrepo = renterrepo;
        }

        public void DeleteRenter(string renterid)
        {
            renterrepo.Delete(renterid);
        }

        public void InsertRenter(Renters renter)
        {
            renterrepo.Insert(renter);
        }

        public IQueryable<Renters> PrintRenters()
        {
            return renterrepo.Print();
        }

        public void UpdateRenter(string renterid, Renters renter)
        {
            renterrepo.Update(renterid, renter);
        }
    }
}
