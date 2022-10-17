using MMABooksBusinessClasses;
using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Text;

namespace MMABooksTests
{
    public class ProductTests
    {
        private Product p;
        private Product def;

        [SetUp]
        public void SetUp()
        {
            p = new Product("AA10", "My Product Description.", (decimal)1.00, 100);
            def = new Product();
        }

        [Test]
        public void DefaultConstructorTest()
        {
            Assert.IsNotNull(def);
            Assert.AreEqual(null, def.ProductCode);
            Assert.AreEqual(null, def.Description);
            Assert.AreEqual(0, def.UnitPrice);
            Assert.AreEqual(0, def.OnHandQuantity);
        }

        [Test]
        public void OverloadConstructorTest()
        {
            Assert.IsNotNull(p);
            Assert.AreEqual("AA10", p.ProductCode);
            Assert.AreEqual("My Product Description.", p.Description);
            Assert.AreEqual((decimal)1.00, p.UnitPrice);
            Assert.AreEqual(100, p.OnHandQuantity);
        }

        [Test]
        public void TestCodeSetter()
        {
            p.ProductCode = "BB20";
            Assert.AreNotEqual("AA10", p.ProductCode);
            Assert.AreEqual("BB20", p.ProductCode);
        }

        [Test]
        public void TestDescSetter()
        {
            p.Description = "This is a different description.";
            Assert.AreNotEqual("My Product Description.", p.Description);
            Assert.AreEqual("This is a different description.", p.Description);
        }

        [Test]
        public void TestPriceSetter()
        {
            p.UnitPrice = (decimal)10.00;
            Assert.AreNotEqual((decimal)1.00, p.UnitPrice);
            Assert.AreEqual((decimal)10.00, p.UnitPrice);
        }

        [Test]
        public void TestOnHandSetter()
        {
            p.OnHandQuantity = 50;
            Assert.AreNotEqual(100, p.OnHandQuantity);
            Assert.AreEqual(50, p.OnHandQuantity);
        }
    }
}
