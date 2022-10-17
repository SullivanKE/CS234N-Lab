using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;
using MMABooksDBClasses;

namespace MMABooksTests
{
    [TestFixture]
    public class ProductDBTests
    {
        Product p1;
        Product p2;
        [SetUp]
        public void SetUp()
        {
            p1 = new Product("A4CS", "Murach's ASP.NET 4 Web Programming with C# 2010", (decimal)56.5000, 4637);
            p2 = new Product("BB10", "Test desc 2", (decimal)10.00, 50);
        }

        [Test]
        public void TestGetProduct()
        {
            Product p = new Product();
            p = ProductDB.GetProduct("A4CS");
            Assert.IsNotNull(p);
            Assert.AreEqual("A4CS", p.ProductCode);
        }

        [Test]
        public void TestAddProduct()
        {
            string productCode = ProductDB.AddProduct(p2);
            Assert.AreEqual("BB10", productCode);
        }

        [Test]
        public void TestDeleteProduct()
        {
            ProductDB.AddProduct(p2);
            Assert.IsTrue(ProductDB.DeleteProduct(p2));
        }

        [Test]
        public void TestUpdateProduct()
        {
            ProductDB.AddProduct(p2);
            Product p = new Product("CC30", "Another Description", (decimal)50.00, 1234);

            Assert.IsTrue(ProductDB.UpdateProduct(p, p2));

        }

        [Test]
        public void TestGetList()
        {
            List<Product> products = ProductDB.GetList();
            Assert.AreEqual(17, products.Count);
            Assert.AreEqual("A4CS", products[0].ProductCode);
        }

    }
}
