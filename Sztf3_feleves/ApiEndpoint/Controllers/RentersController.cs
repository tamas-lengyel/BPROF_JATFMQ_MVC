using Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEndpoint.Controllers
{
    [Route("renter")]
    [ApiController]
    public class RentersController : ControllerBase
    {
        RentersLogic rLogic;

        public RentersController(RentersLogic rLogic)
        {
            this.rLogic = rLogic;
        }

        [HttpDelete("{renterid}")]
        public void DeleteRenter(string renterid)
        {
            rLogic.DeleteRenter(renterid);
        }

        [HttpPost]
        public void InsertRenter([FromBody] Renters renter)
        {
            renter.RenterId = Guid.NewGuid().ToString();
            rLogic.InsertRenter(renter);
        }

        [HttpGet("{renterid}")]
        public Renters GetOneRenter(string renterid)
        {
            return rLogic.GetOneRenter(renterid);
        }

        [HttpGet]
        public IQueryable<Renters> PrintRenters()
        {
            return rLogic.PrintRenters();
        }

        [HttpPut("{renterid}")]
        public void UpdateRenter(string renterid, Renters renter)
        {
            rLogic.UpdateRenter(renterid, renter);
        }
    }
}
