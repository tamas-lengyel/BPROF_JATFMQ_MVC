using Moq;
using NUnit.Framework;
using Repository;
using System;
using Models;
using System.Collections.Generic;
using System.Linq;
using Logic;

namespace Tests
{
    //3x non-crud
    //5x crud (insert, remove, update, getall, getone)

    [TestFixture]
    public class LogicTest
    {
        [Test]
        public void TestGetAllCars()
        {
            Mock<IRepository<Cars>> mockedRepo = new Mock<IRepository<Cars>>
                (MockBehavior.Loose);
            List<Cars> cars = new List<Cars>
            {
                new Cars(){ Make="Audi", Model="A5"},
                new Cars(){ Make="Ford", Model="Mondeo"},
                new Cars(){ Make="Suzuki", Model="Swift"},
                new Cars(){ Make="VW", Model="Transporter"}
            };
            List<Cars> expectedCars = new List<Cars>() 
            { 
                new Cars(){ Make="Audi", Model="A5"},
                new Cars(){ Make="Ford", Model="Mondeo"},
                new Cars(){ Make="Suzuki", Model="Swift"},
                new Cars(){ Make="VW", Model="Transporter"}
            };

            mockedRepo.Setup(repo => repo.Print()).Returns(cars.AsQueryable());
            CarsLogic logic = new CarsLogic(mockedRepo.Object);

            //Act
            var result = logic.PrintCars();

            //Assert
            Assert.That(result.Count, Is.EqualTo(expectedCars.Count));
            Assert.That(result, Is.EquivalentTo(expectedCars));

            //Verify
            mockedRepo.Verify(repo => repo.Print(), Times.Once);
        }

        [Test]
        public void TestAddSalon()
        {
            Mock<IRepository<Salons>> salonRepo = new Mock<IRepository<Salons>>();
            Salons salon = new Salons() { City="Budapest", PostalCode="1132", Address="Nemtudom utca 12." };
            salonRepo.Setup(repo => repo.Insert(It.IsAny<Salons>()));
            SalonsLogic logic = new SalonsLogic(salonRepo.Object);

            logic.InsertSalon(salon);

            salonRepo.Verify(repo => repo.Insert(salon), Times.Once);
        }

        [Test]
        public void TestDeletingRenter()
        {
            Mock<IRepository<Renters>> renterRepo = new Mock<IRepository<Renters>>();
            Renters renter = new Renters()
            {
                RenterId = Guid.NewGuid().ToString(),
                Name = "Kiss Gabor",
                PostalCode = "4034",
                City = "Debrecen",
                Address = "Elso utca 1.",
                Email = "kissgabor@upenn.edu",
                PhoneNumber = "+31 880 308 7288",
                RentedDays = 11
            };
            renterRepo.Setup(repo => repo.Delete(It.IsAny<string>()));
            RentersLogic logic = new RentersLogic(renterRepo.Object);

            logic.DeleteRenter(renter.RenterId);

            renterRepo.Verify(repo => repo.Delete(renter.RenterId), Times.Once);
        }

        [Test]
        public void TestUpdatingSalon()
        {
            Mock<IRepository<Salons>> salonRepo = new Mock<IRepository<Salons>>();
            Salons salon = new Salons()
            {
                SalonId = Guid.NewGuid().ToString(),
                City = "Sopron",
                Address = "Zrínyi Miklós u. 32",
                PostalCode = "9400"
            };
            salonRepo.Setup(repo => repo.Update(It.IsAny<string>(), It.IsAny<Salons>()));
            SalonsLogic logic = new SalonsLogic(salonRepo.Object);

            logic.UpdateSalon(salon.SalonId, salon);

            salonRepo.Verify(repo => repo.Update(salon.SalonId, salon), Times.Once);
        }

        [Test]
        public void TestGetOneCar()
        {
            Mock<IRepository<Cars>> mockedRepo = new Mock<IRepository<Cars>>();
            List<Cars> cars = new List<Cars>
            {
                new Cars(){ CarId = Guid.NewGuid().ToString(), Make="Audi", Model="A5"},
                new Cars(){ CarId = Guid.NewGuid().ToString(), Make="Ford", Model="Mondeo"},
                new Cars(){ CarId = Guid.NewGuid().ToString(), Make="Suzuki", Model="Swift"},
                new Cars(){ CarId = Guid.NewGuid().ToString(), Make="VW", Model="Transporter"}
            };
            Cars expectedCar = new Cars() { CarId = Guid.NewGuid().ToString(), Make = "Suzuki", Model = "Swift" };

            mockedRepo.Setup(repo => repo.GetOneObj(cars[2].CarId)).Returns(expectedCar);
            CarsLogic logic = new CarsLogic(mockedRepo.Object);

            var result = logic.GetOneCar(cars[2].CarId);

            Assert.That(result, Is.EqualTo(expectedCar));

            mockedRepo.Verify(repo => repo.GetOneObj(cars[2].CarId), Times.Once);
        }

        /***********************************NON-CRUD***********************************/

        Mock<IRepository<Cars>> carRepo;
        Mock<IRepository<Renters>> renterRepo;
        Mock<IRepository<Salons>> salonRepo;

        double expectedAVG;
        IEnumerable<NumberOfCarsinEachsalon> NumberOfCars;
        IEnumerable<Renters> RentedAudis;

        private StatsLogic CreateLogicWithMocks()
        {
            carRepo = new Mock<IRepository<Cars>>();
            renterRepo = new Mock<IRepository<Renters>>();
            salonRepo = new Mock<IRepository<Salons>>();

            List<Salons> sList = new List<Salons>()
            {
                new Salons() { SalonId = Guid.NewGuid().ToString(), City = "Budapest",
                    Address = "Liszt Ferenc International Airport Terminal 2", PostalCode = "2200" },
                new Salons() { SalonId = Guid.NewGuid().ToString(), City = "Győr",
                    Address = "Puskás Tivadar u. 9", PostalCode = "9027" },
                new Salons() { SalonId = Guid.NewGuid().ToString(), City = "Sopron",
                    Address = "Zrínyi Miklós u. 32", PostalCode = "9400" }
            };

            List<Cars> cList = new List<Cars>
            {
                new Cars(){ CarId = Guid.NewGuid().ToString(), Make = "Audi", Model = "A3", PricePerDay = 41567, SalonId = sList[2].SalonId, Available = true },
                new Cars(){ CarId = Guid.NewGuid().ToString(), Make = "Volkswagen", Model = "Transporter", PricePerDay = 53481, SalonId = sList[1].SalonId, Available = true },
                new Cars(){ CarId = Guid.NewGuid().ToString(), Make = "Toyota", Model = "C-HR", PricePerDay = 30537, SalonId = sList[0].SalonId, Available = true },
                new Cars(){ CarId = Guid.NewGuid().ToString(), Make = "Mitsubishi", Model = "Lancer Evolution VIII MR", PricePerDay = 296378, SalonId = sList[0].SalonId, Available = true },
                new Cars(){ CarId = Guid.NewGuid().ToString(), Make = "Nissan", Model = "300ZX", PricePerDay = 198375, SalonId = sList[2].SalonId, Available = true },
                new Cars(){ CarId = Guid.NewGuid().ToString(), Make = "Audi", Model = "A4", PricePerDay = 85397, SalonId = sList[1].SalonId, Available = true }
            };

            List<Renters> rList = new List<Renters>()
            {
                new Renters(){ RenterId = Guid.NewGuid().ToString(), Name="Kiss Gabor", CarId = cList[3].CarId },
                new Renters(){ RenterId = Guid.NewGuid().ToString(), Name = "Nagy Aron", CarId = cList[4].CarId },
                new Renters(){ RenterId = Guid.NewGuid().ToString(), Name = "Toth Eszter", CarId = cList[5].CarId },
                new Renters(){ RenterId = Guid.NewGuid().ToString(), Name = "Jerrome Wrightem", CarId = cList[0].CarId },
                new Renters(){ RenterId = Guid.NewGuid().ToString(), Name = "Lakatos Brendon", CarId = cList[1].CarId }
            };

            expectedAVG = 163457.5;

            NumberOfCars = new List<NumberOfCarsinEachsalon>()
            {
                new NumberOfCarsinEachsalon(){ Address="Liszt Ferenc International Airport Terminal 2", CountedCars = 2},
                new NumberOfCarsinEachsalon(){ Address="Puskás Tivadar u. 9", CountedCars = 2},
                new NumberOfCarsinEachsalon(){ Address="Zrínyi Miklós u. 32", CountedCars = 2}
            };

            RentedAudis = new List<Renters>
            {
                new Renters(){ RenterId = rList[2].RenterId, Name = "Toth Eszter", CarId = cList[5].CarId },
                new Renters(){ RenterId = rList[3].RenterId, Name = "Jerrome Wrightem", CarId = cList[0].CarId },
            };

            carRepo.Setup(repo => repo.Print()).Returns(cList.AsQueryable());
            salonRepo.Setup(repo => repo.Print()).Returns(sList.AsQueryable());
            renterRepo.Setup(repo => repo.Print()).Returns(rList.AsQueryable());

            return new StatsLogic(salonRepo.Object, carRepo.Object, renterRepo.Object);
        }

        [Test]
        public void TestAvgPriceOfCarsFromBudapest()
        {
            var logic = CreateLogicWithMocks();
            var actualAvg = logic.AvgPriceOfCarsFromBudapest();

            Assert.That(actualAvg, Is.EqualTo(expectedAVG));

            carRepo.Verify(repo => repo.Print(), Times.Once);
            salonRepo.Verify(repo => repo.Print(), Times.Once);
            renterRepo.Verify(repo => repo.Print(), Times.Never);
        }

        [Test]
        public void TestNumberOfCarsInEachSalon()
        {
            var logic = CreateLogicWithMocks();
            var  vmi = logic.NumberOfCarsInEachSalon();

            Assert.That(vmi, Is.EquivalentTo(NumberOfCars));

            carRepo.Verify(repo => repo.Print(), Times.Once);
            salonRepo.Verify(repo => repo.Print(), Times.Once);
            renterRepo.Verify(repo => repo.Print(), Times.Never);
        }

        [Test]
        public void TestPrintOnlyRentersThatRentedAudis()
        {
            var logic = CreateLogicWithMocks();
            var vmi = logic.PrintOnlyRentersThatRentedAudis();

            Assert.That(vmi, Is.EquivalentTo(RentedAudis));

            carRepo.Verify(repo => repo.Print(), Times.Once);
            salonRepo.Verify(repo => repo.Print(), Times.Never);
            renterRepo.Verify(repo => repo.Print(), Times.Once);
        }
    }
}
