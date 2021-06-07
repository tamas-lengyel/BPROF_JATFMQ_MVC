using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEndpoint.Controllers
{
    [Authorize]
    [Route("cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        CarsLogic cLogic;

        public CarsController(CarsLogic cLogic)
        {
            this.cLogic = cLogic;
        }

        [HttpDelete("{carid}")]
        public void DeleteCar(string carid)
        {
            cLogic.DeleteCar(carid);
        }

        [HttpPost]
        public void InsertCar([FromBody] Cars car)
        {
            car.CarId = Guid.NewGuid().ToString();
            cLogic.InsertCar(car);
        }

        [HttpGet("{carid}")]
        public Cars GetOneCar(string carid)
        {
            return cLogic.GetOneCar(carid);
        }

        [HttpGet]
        public IQueryable<Cars> PrintCars()
        {
            return cLogic.PrintCars();
        }

        [HttpPut("{carid}")]
        public void UpdateCar(string carid, Cars car)
        {
            cLogic.UpdateCar(carid, car);
        }
    }
}
