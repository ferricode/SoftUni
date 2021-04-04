using NUnit.Framework;
using System;
using System.Collections.Generic;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        //private UnitCar car;
        //private UnitDriver driver;
        //private Dictionary<string, UnitDriver> drivers;

        [SetUp]
        public void Setup()
        {
            //car = new UnitCar("Nissan", 65, 450);
            //driver = new UnitDriver("Feri", car);
        }

        [Test]
        public void AddDriverMethod_ShouldThorwException_WhenDriverIsNull()
        {
            var raceEntry = new RaceEntry();

            Exception ex = Assert.Throws<InvalidOperationException>(() =>
              {
                  raceEntry.AddDriver(null);
              });
            Assert.AreEqual(ex.Message, "Driver cannot be null.");
        }
        [Test]
        public void AddDriverMethod_ShouldThorwException_WhenDriverIsExisting()
        {
            var raceEntry = new RaceEntry();

            var driver = new UnitDriver("Feri", new UnitCar("Nissan", 65, 60));
            raceEntry.AddDriver(driver);

            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.AddDriver(driver);
            });
            Assert.AreEqual(ex.Message, $"Driver {driver.Name} is already added.");
        }
        [Test]
        public void AddDriverMethod_ShouldAddDriverCorrectly()
        {
            var raceEntry = new RaceEntry();

            var driver = new UnitDriver("Feri", new UnitCar("Nissan", 65, 60));
            string result = raceEntry.AddDriver(driver);


            Assert.AreEqual(result, $"Driver {driver.Name} added in race.");
            Assert.AreEqual(1, raceEntry.Counter);
        }

        [Test]
        public void CalculateAverageHorsePower_ThrowInvalidOperationException_When_DriverCountIsLessThanMinParticipants()
        {
            var raceEntry = new RaceEntry();
            var car = new UnitCar("Nissan", 65, 60);
            var driver = new UnitDriver("Feri", car);
            raceEntry.AddDriver(driver);

            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.CalculateAverageHorsePower();
            });


            Assert.AreEqual(ex.Message, "The race cannot start with less than 2 participants.");
        }

        [Test]
        public void CalculateAverageHorsePower__ShouldWork()
        {
            var raceEntry = new RaceEntry();
            var car = new UnitCar("Nissan", 65, 60);
            var driver = new UnitDriver("Feri", car);
            raceEntry.AddDriver(driver);

            var car1 = new UnitCar("Nissan", 65, 60);
            var driver1 = new UnitDriver("Gogi", car);
            raceEntry.AddDriver(driver1);

            var car2 = new UnitCar("Nissan", 65, 60);
            var driver2 = new UnitDriver("Pepi", car);
            raceEntry.AddDriver(driver2);

            var result = raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(result, 65.00);
        }

    }
}