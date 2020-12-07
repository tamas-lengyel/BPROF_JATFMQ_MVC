﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Logic;

namespace Sztf3_feleves.Controllers
{
    public class HomeController : Controller
    {
        CarsLogic carsLogic;
        SalonsLogic salonsLogic;
        RentersLogic rentersLogic;

        public HomeController(CarsLogic carsLogic, SalonsLogic salonsLogic, RentersLogic rentersLogic)
        {
            this.carsLogic = carsLogic;
            this.salonsLogic = salonsLogic;
            this.rentersLogic = rentersLogic;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        public IActionResult GenerateDB()
        {
            /*Salons *************************************/

            Salons s = new Salons { SalonId = Guid.NewGuid().ToString(), City = "Budapest", 
                Address = "Liszt Ferenc International Airport Terminal 2", PostalCode = "2200" };
            Salons s1 = new Salons { SalonId = Guid.NewGuid().ToString(), City = "Budapest", 
                Address = "Lövőház u. 2", PostalCode = "1024" };
            Salons s2 = new Salons { SalonId = Guid.NewGuid().ToString(), City = "Budapest", 
                Address = "Arany János u. 26-28", PostalCode = "1051" };
            Salons s3 = new Salons { SalonId = Guid.NewGuid().ToString(), City = "Győr", 
                Address = "Puskás Tivadar u. 9", PostalCode = "9027" };
            Salons s4 = new Salons { SalonId = Guid.NewGuid().ToString(), City = "Sopron", 
                Address = "Zrínyi Miklós u. 32", PostalCode = "9400" };

            salonsLogic.InsertSalon(s);
            salonsLogic.InsertSalon(s1);
            salonsLogic.InsertSalon(s2);
            salonsLogic.InsertSalon(s3);
            salonsLogic.InsertSalon(s4);
            /*Cars ***************************************/

            Cars c = new Cars { CarId = Guid.NewGuid().ToString(), Make = "Audi", Model = "A6", ModelYear = 2019, 
                BodyType = "Sedan", CombFuelEco = 9.4, Available = false, PricePerDay = 102100, SalonId = s2.SalonId };
            Cars c1 = new Cars { CarId = Guid.NewGuid().ToString(), Make = "Audi", Model = "A4", ModelYear = 2018, 
                BodyType = "Wagon", CombFuelEco = 7.5, Available = true, PricePerDay = 85397, SalonId = s2.SalonId };
            Cars c2 = new Cars { CarId = Guid.NewGuid().ToString(), Make = "Audi", Model = "A1", ModelYear = 2020, 
                BodyType = "Hatchback", CombFuelEco = 4.7, Available = true, PricePerDay = 34972, SalonId = s3.SalonId };
            Cars c3 = new Cars { CarId = Guid.NewGuid().ToString(), Make = "Audi", Model = "A3", ModelYear = 2020, 
                BodyType = "Hatchback", CombFuelEco = 7.8, Available = true, PricePerDay = 41567, SalonId = s.SalonId };
            Cars c4 = new Cars { CarId = Guid.NewGuid().ToString(), Make = "Toyota", Model = "C-HR", ModelYear = 2018, 
                BodyType = "SUV", CombFuelEco = 8.1, Available = false, PricePerDay = 30537, SalonId = s.SalonId };
            Cars c5 = new Cars { CarId = Guid.NewGuid().ToString(), Make = "Volkswagen", Model = "Transporter", ModelYear = 2017, 
                BodyType = "Van", CombFuelEco = 7.5, Available = false, PricePerDay = 53481, SalonId = s1.SalonId };
            Cars c6 = new Cars { CarId = Guid.NewGuid().ToString(), Make = "Nissan", Model = "GT-R", ModelYear = 2020, 
                BodyType = "Coupe", CombFuelEco = 13, Available = true, PricePerDay = 368798, SalonId = s2.SalonId };
            Cars c7 = new Cars { CarId = Guid.NewGuid().ToString(), Make = "Nissan", Model = "300ZX", ModelYear = 2000, 
                BodyType = "Coupe", CombFuelEco = 13, Available = false, PricePerDay = 198375, SalonId = s2.SalonId };
            Cars c8 = new Cars { CarId = Guid.NewGuid().ToString(), Make = "Mitsubishi", Model = "Lancer Evolution VIII MR", ModelYear = 2005, 
                BodyType = "Sedan", CombFuelEco = 10.9, Available = false, PricePerDay = 296378, SalonId = s2.SalonId };

            carsLogic.InsertCar(c);
            carsLogic.InsertCar(c1);
            carsLogic.InsertCar(c2);
            carsLogic.InsertCar(c3);
            carsLogic.InsertCar(c4);
            carsLogic.InsertCar(c5);
            carsLogic.InsertCar(c6);
            carsLogic.InsertCar(c7);
            carsLogic.InsertCar(c8);
            /*Renters ************************************/

            Renters r = new Renters { RenterId = Guid.NewGuid().ToString(), Name="Moll Gothliff", 
                PostalCode="4384", City="Vlissingen", Address= "79 Lighthouse Bay Plaza", 
                Email= "mgothliff9@upenn.edu", PhoneNumber="+31 880 308 7288", RentedDays=11, CarId=c.CarId };
            Renters r1 = new Renters { RenterId = Guid.NewGuid().ToString(), Name= "Carol-jean Pantone", 
                PostalCode= "571 36", City= "Nässjö", Address= "1614 Spohn Point", 
                Email= "cpantoneh@jugem.jp", PhoneNumber="+46 697 322 8112", RentedDays=4, CarId=c4.CarId };
            Renters r2 = new Renters { RenterId = Guid.NewGuid().ToString(), Name= "Odilia Olivello", 
                PostalCode= "11250-000", City= "Guanshan", Address= "9298 Dexter Pass", 
                Email= "oolivelloc@seesaa.net", PhoneNumber= "+86 918 333 5232", RentedDays=21, CarId=c5.CarId };
            Renters r3 = new Renters { RenterId = Guid.NewGuid().ToString(), Name= "Jerrome Wrightem", 
                PostalCode= "6821", City= "Daqiao", Address= "80 Havey Alley", 
                Email= "jwrightemk@stanford.edu", PhoneNumber= "+86 619 977 2794", RentedDays=30, CarId=c7.CarId };
            Renters r4 = new Renters { RenterId = Guid.NewGuid().ToString(), Name= "Etheline Geroldo", 
                PostalCode= "3352", City= "Pampamarca", Address= "44638 Schiller Pass", 
                Email= "egeroldog@prnewswire.com", PhoneNumber= "+51 442 752 0329", RentedDays=4, CarId=c8.CarId };

            rentersLogic.InsertRenter(r);
            rentersLogic.InsertRenter(r1);
            rentersLogic.InsertRenter(r2);
            rentersLogic.InsertRenter(r3);
            rentersLogic.InsertRenter(r4);

            

            return RedirectToAction(nameof(Index));
        }

        /*****************************************************************/
        /**************************** SALON ******************************/
        /*****************************************************************/

        [HttpGet]
        public IActionResult AddNewSalon()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewSalon(Salons salon)
        {
            salon.SalonId = Guid.NewGuid().ToString();
            salonsLogic.InsertSalon(salon);

            return RedirectToAction(nameof(ListSalons));
        }

        [HttpGet]
        public IActionResult ListSalons()
        {
            return View(salonsLogic.PrintSalons());
        }

        /*****************************************************************/
        /***************************** CAR *******************************/
        /*****************************************************************/

        [HttpGet]
        public IActionResult AddNewCar(string id)
        {
            return View(nameof(AddNewCar),id);
        }

        [HttpPost]
        public IActionResult AddNewCar(Cars car)
        {
            car.CarId = Guid.NewGuid().ToString();
            carsLogic.InsertCar(car);

            return RedirectToAction(nameof(ListSalons));
        }

        [HttpGet]
        public IActionResult ListCars()
        {
            return View(carsLogic.PrintCars());
        }

        [HttpGet]
        public IActionResult EditCar(string id)
        {
            return View(carsLogic.PrintCars());
        }

        [HttpPost]
        public IActionResult EditCar(string oldid, Cars c)
        {
            return View(carsLogic.PrintCars());
        }

        /*****************************************************************/
        /*************************** Renter ******************************/
        /*****************************************************************/

        [HttpGet]
        public IActionResult AddNewRenter(string id)
        {
            return View(nameof(AddNewRenter),id);
        }

        [HttpPost]
        public IActionResult AddNewRenter(Renters renter)
        {
            renter.RenterId = Guid.NewGuid().ToString();
            rentersLogic.InsertRenter(renter);

            return RedirectToAction(nameof(ListCars));
        }

        [HttpGet]
        public IActionResult ListRenters()
        {
            return View(rentersLogic.PrintRenters());
        }
    }
}
