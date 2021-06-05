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
    [Route("salons")]
    [ApiController]
    public class SalonsController : ControllerBase
    {
        SalonsLogic sLogic;

        public SalonsController(SalonsLogic sLogic)
        {
            this.sLogic = sLogic;
        }

        [HttpDelete("{salonid}")]
        public void DeleteSalon(string salonid)
        {
            sLogic.DeleteSalon(salonid);
        }

        [HttpPost]
        public void InsertSalon([FromBody] Salons salon)
        {
            salon.SalonId = Guid.NewGuid().ToString();
            sLogic.InsertSalon(salon);
        }

        [HttpGet("{salonid}")]
        public Salons GetOneSalon(string salonid)
        {
            return sLogic.GetOneSalon(salonid);
        }

        [HttpGet]
        public IQueryable<Salons> PrintSalons()
        {
            return sLogic.PrintSalons();
        }

        [HttpPut("{salonid}")]
        public void UpdateSalon(string salonid, [FromBody] Salons salon)
        {
            sLogic.UpdateSalon(salonid, salon);
        }
    }
}
