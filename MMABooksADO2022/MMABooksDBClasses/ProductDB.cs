using System;
using System.Collections.Generic;
using System.Text;

using MySql.Data.MySqlClient;
using System.Data;
using MMABooksBusinessClasses;

namespace MMABooksDBClasses
{
    public static class ProductDB
    {
        public static Product GetProduct(string productCode)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string selectStatement
                = "SELECT ProductCode, Description, UnitPrice, OnHandQuantity "
                + "FROM Products "
                + "WHERE ProductCode = @ProductCode";

            MySqlCommand selectCommand =
                new MySqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ProductCode", productCode);

            try
            {
                connection.Open();
                MySqlDataReader prodReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (prodReader.Read())
                {
                    Product product = new Product();
                    product.ProductCode = prodReader["ProductCode"].ToString();
                    product.Description = prodReader["Description"].ToString();
                    product.UnitPrice = (decimal)prodReader["UnitPrice"];
                    product.OnHandQuantity = (int)prodReader["OnHandQuantity"];

                    return product;
                }
                else
                {
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static string AddProduct(Product p)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string insertStatement
                = "INSERT Products " + 
                "(ProductCode, Description, UnitPrice, OnHandQuantity) "
                + "VALUES (@ProductCode, @Description, @UnitPrice, @OnHandQuantity)";

            MySqlCommand insertCommand =
                new MySqlCommand(insertStatement, connection);

            insertCommand.Parameters.AddWithValue("@ProductCode", p.ProductCode);
            insertCommand.Parameters.AddWithValue("@Description", p.Description);
            insertCommand.Parameters.AddWithValue("@UnitPrice", p.UnitPrice);
            insertCommand.Parameters.AddWithValue("@OnHandQuantity", p.OnHandQuantity);

            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();

                return p.ProductCode;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool DeleteProduct(Product p)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string deleteStatement = 
                "DELETE FROM Products " +
                "WHERE ProductCode = @ProductCode " +
                "AND Description = @Description " +
                "AND UnitPrice = @UnitPrice " +
                "AND OnHandQuantity = @OnHandQuantity";

            MySqlCommand deleteCommand =
                new MySqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue("@ProductCode", p.ProductCode);
            deleteCommand.Parameters.AddWithValue("@Description", p.Description);
            deleteCommand.Parameters.AddWithValue("@UnitPrice", p.UnitPrice);
            deleteCommand.Parameters.AddWithValue("@OnHandQuantity", p.OnHandQuantity);

            try
            {
                connection.Open();
                int results = deleteCommand.ExecuteNonQuery();
                return results == 1;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool UpdateProduct(Product newP, Product oldP)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string updateStatement = 
                "UPDATE Products SET " +
                "ProductCode = @NewProductCode, " +
                "Description = @NewDescription, " +
                "UnitPrice = @NewUnitPrice, " +
                "OnHandQuantity = @NewOnHandQuantity " +
                "WHERE ProductCode = @OldProductCode " +
                "AND Description = @OldDescription " +
                "AND UnitPrice = @OldUnitPrice " +
                "AND OnHandQuantity = @OldOnHandQuantity";

            MySqlCommand updateCommand =
                new MySqlCommand(updateStatement, connection);

            updateCommand.Parameters.AddWithValue(
                "@OldProductCode", oldP.ProductCode);
            updateCommand.Parameters.AddWithValue(
                "@NewProductCode", newP.ProductCode);

            updateCommand.Parameters.AddWithValue(
                "@OldDescription", oldP.Description);
            updateCommand.Parameters.AddWithValue(
                "@NewDescription", newP.Description);

            updateCommand.Parameters.AddWithValue(
                "@OldUnitPrice", oldP.UnitPrice);
            updateCommand.Parameters.AddWithValue(
                "@NewUnitPrice", newP.UnitPrice);

            updateCommand.Parameters.AddWithValue(
                "@OldOnHandQuantity", oldP.OnHandQuantity);
            updateCommand.Parameters.AddWithValue(
                "@NewOnHandQuantity", newP.OnHandQuantity);

            try
            {
                connection.Open();
                int results = updateCommand.ExecuteNonQuery();
                return results == 1;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static List<Product> GetList()
        {

            List<Product> products = new List<Product>();

            MySqlConnection connection = MMABooksDB.GetConnection();
            string selectStatement
                = "SELECT ProductCode, Description, UnitPrice, OnHandQuantity "
                + "FROM Products "
                + "ORDER BY ProductCode";

            MySqlCommand selectCommand =
                new MySqlCommand(selectStatement, connection);

            try
            {
                connection.Open();
                MySqlDataReader prodReader =
                    selectCommand.ExecuteReader();
                while (prodReader.Read())
                {
                    Product product = new Product();
                    product.ProductCode = prodReader["ProductCode"].ToString();
                    product.Description = prodReader["Description"].ToString();
                    product.UnitPrice = (decimal)prodReader["UnitPrice"];
                    product.OnHandQuantity = (int)prodReader["OnHandQuantity"];

                    products.Add(product);
                    
                }
                prodReader.Close();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return products;
        }
    }
}
