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
    //[Authorize]
    [Route("generatedata")]
    [ApiController]
    public class OtherController : ControllerBase
    {
        SalonsLogic sLogic;
        CarsLogic cLogic;
        RentersLogic rLogic;

        public OtherController(SalonsLogic sLogic, CarsLogic cLogic, RentersLogic rLogic)
        {
            this.sLogic = sLogic;
            this.cLogic = cLogic;
            this.rLogic = rLogic;
        }

        [HttpGet]
        public void GenerateDB()
        {
            /*Salons *************************************/

            Salons s = new Salons
            {
                SalonId = Guid.NewGuid().ToString(),
                City = "Budapest",
                Address = "Liszt Ferenc International Airport Terminal 2",
                PostalCode = "2200"
            };
            Salons s1 = new Salons
            {
                SalonId = Guid.NewGuid().ToString(),
                City = "Budapest",
                Address = "Lövőház u. 2",
                PostalCode = "1024"
            };
            Salons s2 = new Salons
            {
                SalonId = Guid.NewGuid().ToString(),
                City = "Budapest",
                Address = "Arany János u. 26-28",
                PostalCode = "1051"
            };
            Salons s3 = new Salons
            {
                SalonId = Guid.NewGuid().ToString(),
                City = "Győr",
                Address = "Puskás Tivadar u. 9",
                PostalCode = "9027"
            };
            Salons s4 = new Salons
            {
                SalonId = Guid.NewGuid().ToString(),
                City = "Sopron",
                Address = "Zrínyi Miklós u. 32",
                PostalCode = "9400"
            };

            /*Cars ***************************************/

            Cars c = new Cars
            {
                CarId = Guid.NewGuid().ToString(),
                Make = "Audi",
                Model = "A6",
                ModelYear = 2019,
                BodyType = "Sedan",
                CombFuelEco = 9.4,
                Available = false,
                PricePerDay = 102100,
                SalonId = s2.SalonId
            };
            Cars c1 = new Cars
            {
                CarId = Guid.NewGuid().ToString(),
                Make = "Audi",
                Model = "A4",
                ModelYear = 2018,
                BodyType = "Wagon",
                CombFuelEco = 7.5,
                Available = true,
                PricePerDay = 85397,
                SalonId = s2.SalonId
            };
            Cars c2 = new Cars
            {
                CarId = Guid.NewGuid().ToString(),
                Make = "Audi",
                Model = "A1",
                ModelYear = 2020,
                BodyType = "Hatchback",
                CombFuelEco = 4.7,
                Available = true,
                PricePerDay = 34972,
                SalonId = s3.SalonId
            };
            Cars c3 = new Cars
            {
                CarId = Guid.NewGuid().ToString(),
                Make = "Audi",
                Model = "A3",
                ModelYear = 2020,
                BodyType = "Hatchback",
                CombFuelEco = 7.8,
                Available = true,
                PricePerDay = 41567,
                SalonId = s.SalonId
            };
            Cars c4 = new Cars
            {
                CarId = Guid.NewGuid().ToString(),
                Make = "Toyota",
                Model = "C-HR",
                ModelYear = 2018,
                BodyType = "SUV",
                CombFuelEco = 8.1,
                Available = false,
                PricePerDay = 30537,
                SalonId = s.SalonId
            };
            Cars c5 = new Cars
            {
                CarId = Guid.NewGuid().ToString(),
                Make = "Volkswagen",
                Model = "Transporter",
                ModelYear = 2017,
                BodyType = "Van",
                CombFuelEco = 7.5,
                Available = false,
                PricePerDay = 53481,
                SalonId = s1.SalonId
            };
            Cars c6 = new Cars
            {
                CarId = Guid.NewGuid().ToString(),
                Make = "Nissan",
                Model = "GT-R",
                ModelYear = 2020,
                BodyType = "Coupe",
                CombFuelEco = 13,
                Available = true,
                PricePerDay = 368798,
                SalonId = s2.SalonId
            };
            Cars c7 = new Cars
            {
                CarId = Guid.NewGuid().ToString(),
                Make = "Nissan",
                Model = "300ZX",
                ModelYear = 2000,
                BodyType = "Coupe",
                CombFuelEco = 13,
                Available = false,
                PricePerDay = 198375,
                SalonId = s2.SalonId
            };
            Cars c8 = new Cars
            {
                CarId = Guid.NewGuid().ToString(),
                Make = "Mitsubishi",
                Model = "Lancer Evolution VIII MR",
                ModelYear = 2005,
                BodyType = "Sedan",
                CombFuelEco = 10.9,
                Available = false,
                PricePerDay = 296378,
                SalonId = s2.SalonId
            };

            /*Renters ************************************/

            Renters r = new Renters
            {
                RenterId = Guid.NewGuid().ToString(),
                Name = "Kiss Gabor",
                PostalCode = "4034",
                City = "Debrecen",
                Address = "Elso utca 1.",
                Email = "kissgabor@upenn.edu",
                PhoneNumber = "+31 880 308 7288",
                RentedDays = 11,
                CarId = c.CarId
            };
            Renters r1 = new Renters
            {
                RenterId = Guid.NewGuid().ToString(),
                Name = "Nagy Aron",
                PostalCode = "1111",
                City = "Budapest",
                Address = "Masodik utca 2.",
                Email = "nagyaron@jugem.jp",
                PhoneNumber = "+46 697 322 8112",
                RentedDays = 4,
                CarId = c4.CarId
            };
            Renters r2 = new Renters
            {
                RenterId = Guid.NewGuid().ToString(),
                Name = "Toth Eszter",
                PostalCode = "1020",
                City = "Bécs",
                Address = "Harmadik utca 3.",
                Email = "totheszter@seesaa.net",
                PhoneNumber = "+86 918 333 5232",
                RentedDays = 21,
                CarId = c5.CarId
            };
            Renters r3 = new Renters
            {
                RenterId = Guid.NewGuid().ToString(),
                Name = "Jerrome Wrightem",
                PostalCode = "90019",
                City = "Los Angeles",
                Address = "80 Havey Alley",
                Email = "jwrightemk@stanford.edu",
                PhoneNumber = "+86 619 977 2794",
                RentedDays = 30,
                CarId = c7.CarId
            };
            Renters r4 = new Renters
            {
                RenterId = Guid.NewGuid().ToString(),
                Name = "Lakatos Brendon",
                PostalCode = "9028",
                City = "Győr",
                Address = "Negyedik utca 4.",
                Email = "lakatosbrendong@prnewswire.com",
                PhoneNumber = "+51 442 752 0329",
                RentedDays = 4,
                CarId = c8.CarId
            };


            sLogic.InsertSalon(s);
            sLogic.InsertSalon(s1);
            sLogic.InsertSalon(s2);
            sLogic.InsertSalon(s3);
            sLogic.InsertSalon(s4);

            cLogic.InsertCar(c);
            cLogic.InsertCar(c1);
            cLogic.InsertCar(c2);
            cLogic.InsertCar(c3);
            cLogic.InsertCar(c4);
            cLogic.InsertCar(c5);
            cLogic.InsertCar(c6);
            cLogic.InsertCar(c7);
            cLogic.InsertCar(c8);

            rLogic.InsertRenter(r);
            rLogic.InsertRenter(r1);
            rLogic.InsertRenter(r2);
            rLogic.InsertRenter(r3);
            rLogic.InsertRenter(r4);
        }

        [HttpGet("hello")]
        public string HelloWorld()
        {
            return "Hello";
        } 
    }
}
