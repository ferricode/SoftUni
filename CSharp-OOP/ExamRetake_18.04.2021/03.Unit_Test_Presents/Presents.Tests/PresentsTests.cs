namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class PresentsTests
    {
        private Bag bag;


        [SetUp]
        public void Setup()
        {
            bag = new Bag();
        }

        [Test]
        public void Ctor_InitializedPresents()
        {
            Assert.That(this.bag.GetPresents(), Is.Not.Null);
        }
        [Test]
        public void Count_IsZero_WhenBagIsEmpty()
        {
            Assert.That(this.bag.GetPresents().Count, Is.EqualTo(0));
        }
        [Test]
        public void Create_ThrowsArgumentException_WhenPresentIsNull()
        {
            Present present = null;

            Assert.Throws<ArgumentNullException>(() => bag.Create(present));

        }
        [Test]
        public void Create_ThrowsArgumentException_WhenPresentAlreadyExists()
        {
            Present present = new Present("Key", 3.3);
            bag.Create(present);

            Assert.Throws<InvalidOperationException>(() => bag.Create(present));

        }
        [Test]
        public void Create_AddsPresentToBag()
        {
            string name = "Key";
            Present present = new Present(name, 3.3);
            bag.Create(present);

            Assert.That(bag.GetPresent(name), Is.Not.Null);

        }

        [Test]
        public void Create_AddsPresent_IncreasesCount()
        {

            bag.Create(new Present("Key", 3.3));

            Assert.That(bag.GetPresents().Count, Is.EqualTo(1));

        }
        [Test]
        public void Remove_WhenRemovesExistingPresent()
        {
            Present present = new Present("Key", 3.3);

            bag.Create(present);
            bool result = bag.Remove(present);

            Assert.That(result, Is.True);

        }
        [Test]
        public void Remove_WhenRemovesNonExistingPresent()
        {
            Present present = new Present("Key", 3.3);

            bool result = bag.Remove(present);

            Assert.That(result, Is.False);

        }
        [Test]
        public void GetPresentWithLeastMagic()
        {
            Present present1 = new Present("Key", 7.7);
            Present present2 = new Present("Wallet", 10.0);
            Present present3 = new Present("Phone", 4.0);

            bag.Create(present1);
            bag.Create(present2);
            bag.Create(present3);
            var result = bag.GetPresentWithLeastMagic();

            Assert.That(result, Is.EqualTo(present3));
        }
        [Test]
        public void GetPresent_ReturnsPresentWithName()
        {
            string name = "Key";
            Present present1 = new Present(name, 7.7);
           
            bag.Create(present1);
      
            var result = bag.GetPresent(name);

            Assert.That(result, Is.EqualTo(present1));
        }


    }

}
