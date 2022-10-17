using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;

namespace MMABooksTests
{
    [TestFixture]
    public class CustomerTests
    {
        private Customer def;
        private Customer c;
        private string name = "Mouse, Micky";
        private string address = "101 Main Street";
        private string city = "Orlando";
        private string state = "FL";
        private string zip = "10001";

        [SetUp]
        public void SetUp()
        {
            def = new Customer();
            c = new Customer(1, name, address, city, state, zip);
        }

        [Test]
        public void TestDefaultConstructor()
        {
            Assert.IsNotNull(def);
            Assert.AreEqual(null, def.Name);
            Assert.AreEqual(null, def.Address);
            Assert.AreEqual(null, def.City);
            Assert.AreEqual(null, def.State);
            Assert.AreEqual(null, def.ZipCode);
        }

        [Test]
        public void TestOverloadedConstructor()
        {
            Assert.IsNotNull(c);
            Assert.AreEqual(name, c.Name);
            Assert.AreEqual(address, c.Address);
            Assert.AreEqual(city, c.City);
            Assert.AreEqual(state, c.State);
            Assert.AreEqual(zip, c.ZipCode);
        }

        [Test]
        public void TestNameSetter()
        {
            c.Name = "Mouse, Minny";
            Assert.AreNotEqual(name, c.Name);
            Assert.AreEqual("Mouse, Minny", c.Name);

            c.Address = "102 Main Street";
            Assert.AreNotEqual(name, c.Address);
            Assert.AreEqual("102 Main Street", c.Address);

            c.City = "Chattanooga";
            Assert.AreNotEqual(name, c.City);
            Assert.AreEqual("Chattanooga", c.City);

            c.State = "TN";
            Assert.AreNotEqual(name, c.State);
            Assert.AreEqual("TN", c.State);

            c.ZipCode = "37343";
            Assert.AreNotEqual(name, c.ZipCode);
            Assert.AreEqual("37343", c.ZipCode);
        }
    }
}
