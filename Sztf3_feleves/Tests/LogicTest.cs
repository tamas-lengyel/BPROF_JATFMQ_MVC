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
            List<Cars> expectedCars = new List<Cars>() { cars[0], cars[1], cars[2], cars[3] };

            mockedRepo.Setup(repo => repo.Print()).Returns(cars.AsQueryable());
            CarsLogic logic = new CarsLogic(mockedRepo.Object);

            //Act
            var result = logic.PrintCars();

            //Assert
            Assert.That(result.Count, Is.EqualTo(expectedCars.Count));
            Assert.That(result, Is.EquivalentTo(expectedCars));

            //Verify
            mockedRepo.Verify(repo => repo.Print(), Times.Once);
            //mockedRepo.Verify(repo => repo.GetOne(12), Times.Exactly(0));
            //mockedRepo.Verify(repo => repo.GetOne(It.IsAny<string>()), Times.Never);
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
    }
}
