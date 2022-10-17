using System;
using System.Collections.Generic;
using System.Text;



namespace MMABooksBusinessClasses
{
    public class Product
    {
        private string productCode;
        private string description;
        private decimal unitPrice;
        private int onHandQuantity;

        public Product() 
        {

        }

        public Product(string productCode, string description, decimal unitPrice, int onHandQuantity)
        {
            this.productCode = productCode;
            this.description = description;
            this.unitPrice = unitPrice;
            this.onHandQuantity = onHandQuantity;
        }
        public string ProductCode 
        { 
            get 
            { 
                return productCode; 
            }
            set
            {
                if (value.Length > 0 && value.Length <= 10)
                    productCode = value;
                else
                    throw new ArgumentOutOfRangeException("Product Code must be at least 1 character and no more than 100.");
            }
        }
        public string Description 
        { 
            get 
            { 
                return description; 
            }
            set
            {
                if (value.Length > 0 && value.Length <= 50)
                    description = value;
                else
                    throw new ArgumentOutOfRangeException("Description must be at least 1 character and no more than 50.");
            }
        }

        public decimal UnitPrice 
        { 
            get 
            { 
                return unitPrice; 
            }
            set
            {
                if (value >= (decimal)0)
                    unitPrice = value;
                else
                    throw new ArgumentOutOfRangeException("Product cannot have a negative price.");
            }
        }

        public int OnHandQuantity 
        { 
            get 
            { 
                return onHandQuantity; 
            }
            set
            {
                if (value >= 0)
                    onHandQuantity = value;
                else
                    throw new ArgumentOutOfRangeException("Quantity cannot be less than 0.");
            }
        }

        public override string ToString()
        {
            return ProductCode + ", " + Description + ", " + UnitPrice + ", " + OnHandQuantity;
        }
    }
}
