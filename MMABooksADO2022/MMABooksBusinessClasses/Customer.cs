using System;

namespace MMABooksBusinessClasses
{
    public class Customer
    {
        // there are several warnings in this file related to nullable properties and return values.
        // you can ignore them
        public Customer() { }

        public Customer(int id, string name, string address, string city, string state, string zipcode)
        {
            CustomerID = id;
            Name = name;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipcode;
        }

        private int customerID;
        private string name;
        private string address;
        private string city;
        private string state;
        private string zipCode;
        

        public int CustomerID
        {
            get
            {
                return customerID;
            }
            set
            {
                if (value > 0)
                    customerID = value;
                else
                    throw new ArgumentOutOfRangeException("Customer ID must be a positive integer");
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length > 0 && value.Length <= 100)
                    name = value;
                else
                    throw new ArgumentOutOfRangeException("Name must be at least 1 character and no more than 100.");
            }
        }
        

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                if (value.Length > 0 && value.Length <= 50)
                    address = value;
                else
                    throw new ArgumentOutOfRangeException("Address must be at least 1 character and no more than 50.");
            }
        }

        public string City
        {
            get
            {
                return city;
            }
            set
            {
                if (value.Length > 0 && value.Length <= 20)
                    city = value;
                else
                    throw new ArgumentOutOfRangeException("City must be at least 1 character and no more than 20.");
            }
        }

        public string State
        {
            get
            {
                return state;
            }
            set
            {
                if (value.Length > 0 && value.Length <= 2)
                    state = value;
                else
                    throw new ArgumentOutOfRangeException("State code must be at least 1 character and no more than 2.");
            }
        }

        public string ZipCode
        {
            get
            {
                return zipCode;
            }
            set
            {
                if (value.Length > 0 && value.Length <= 15)
                    zipCode = value;
                else
                    throw new ArgumentOutOfRangeException("Zip code must be at least 1 character and no more than 15.");
            }
        }

        public override string ToString()
        {
            return Name + ", " + Address + ", " + City + ", " + State + ", " + ZipCode;
        }
    }
}
