using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        private Computer computer;
        private ComputerManager computerManager;
        private readonly string initialManufacturer= "Apple";
        private readonly string initialModel= "M1";
        private readonly decimal initialPrice= 2200.00m;

        [SetUp]
        public void Setup()
        {
            computer = new Computer(initialManufacturer, initialModel, initialPrice);
            computerManager = new ComputerManager();
        }

        [Test]
        public void CheckIfComputerConstructorWorksCorrectly()
        {
            Assert.AreEqual(initialPrice, computer.Price);
            Assert.AreEqual(initialManufacturer, computer.Manufacturer);
            Assert.AreEqual(initialModel, computer.Model);
        }
        [Test]
        public void AddComputer_ThrowsException_WhenComputerAlreadyExist()
        {

            Exception ex = Assert.Throws<ArgumentException>(() =>
              {
                  computerManager.AddComputer(computer);
                  computerManager.AddComputer(computer);
              });

            Assert.AreEqual(ex.Message, "This computer already exists.");

        }
        [Test]
        public void AddComputer_AddsComputer_WhenStillNotExist()
        {
            computerManager.AddComputer(computer);

            Assert.IsTrue(computerManager.Computers.Any(c => c.Manufacturer == computer.Manufacturer && c.Model == computer.Model));

        }
        [Test]
        public void WhenRemoveComputer_ShouldSetThatComputerIsRemoved()
        {
            computerManager.AddComputer(computer);
            computerManager.RemoveComputer(computer.Manufacturer, computer.Model);

            Assert.IsFalse(computerManager.Computers.Any(c => c.Manufacturer == computer.Manufacturer && c.Model == computer.Model));

        }
        [Test]
        public void RemoveComputer_ReturnsRemovedComputer()
        {
            computerManager.AddComputer(computer);

            var result = computerManager.RemoveComputer(computer.Manufacturer, computer.Model);

            Assert.AreEqual(result, computer);

        }
        [Test]
        public void GetComputer_WhenGetsComputer()
        {
            computerManager.AddComputer(computer);
            var result = computerManager.GetComputer(computer.Manufacturer, computer.Model);

            Assert.AreEqual(result, computer);

        }
        [Test]
        public void GetComputer_ThrowsException_WhenComputerIsNull()
        {

            Exception ex = Assert.Throws<ArgumentException>(() =>
              {
                  computerManager.GetComputer(computer.Manufacturer, computer.Model);
              });
            Assert.AreEqual(ex.Message, "There is no computer with this manufacturer and model.");

        }
        [Test]
        public void GetComputersByManufacturer_WhereGetsComputersByManufacturer()
        {

            string manufacturer = "Assus";

            computerManager.AddComputer(computer);
            computerManager.AddComputer(new Computer("Assus", "ZenBook 13", 1900.00m));
            computerManager.AddComputer(new Computer("Assus", "ZenBook 14", 2100.00m));

            var collection = this.computerManager.GetComputersByManufacturer(manufacturer);

            Assert.That(collection.Count, Is.EqualTo(2));

        }

    }

}
