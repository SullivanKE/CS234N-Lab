using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;
using MMABooksDBClasses;

namespace MMABooksTests
{
    [TestFixture]
    public class CustomerDBTests
    {

        [Test]
        public void TestGetCustomer()
        {
            Customer c = CustomerDB.GetCustomer(1);
            Assert.AreEqual(1, c.CustomerID);
        }

        [Test]
        public void TestCreateCustomer()
        {
            Customer c = new Customer();
            c.Name = "Mickey Mouse";
            c.Address = "101 Main Street";
            c.City = "Orlando";
            c.State = "FL";
            c.ZipCode = "10101";

            int customerID = CustomerDB.AddCustomer(c);
            c = CustomerDB.GetCustomer(customerID);
            Assert.AreEqual("Mickey Mouse", c.Name);
        }

        [Test]
        public void TestDeleteCustomer()
        {
            Customer c = new Customer();
            c.Name = "Mickey Mouse";
            c.Address = "101 Main Street";
            c.City = "Orlando";
            c.State = "FL";
            c.ZipCode = "10101";

            c.CustomerID = CustomerDB.AddCustomer(c);
            

            Assert.IsTrue(CustomerDB.DeleteCustomer(c));
        }

        [Test]
        public void TestUpdateCustomer()
        {
            Customer c1 = new Customer();
            c1.CustomerID = 1000;
            c1.Name = "Mickey Mouse";
            c1.Address = "101 Main Street";
            c1.City = "Orlando";
            c1.State = "FL";
            c1.ZipCode = "10101";

            Customer c2 = new Customer();
            c2.CustomerID = 1000;
            c2.Name = "Minnie Mouse";
            c2.Address = "202 Test Street";
            c2.City = "Eugene";
            c2.State = "OR";
            c2.ZipCode = "97402";


            c1.CustomerID = CustomerDB.AddCustomer(c1);

            Assert.IsTrue(CustomerDB.UpdateCustomer(c1, c2));
        }
    }
}
