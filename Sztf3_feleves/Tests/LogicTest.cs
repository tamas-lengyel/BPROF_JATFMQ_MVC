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
    }
}
