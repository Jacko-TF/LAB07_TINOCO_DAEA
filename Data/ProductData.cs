using Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class ProductData
    {
        public static List<Product> GetProducts() 
        { 
            List<Product> products = new List<Product>();

            string cadena = Connection.getCadenaConexion();

            SqlConnection connection = new SqlConnection(cadena);

            connection.Open();

            SqlCommand command = new SqlCommand("USP_ListProducts", connection);

            command.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32("product_id");
                string name = reader.GetString("name");
                decimal price = reader.GetDecimal("price");
                int stock  = reader.GetInt32("stock");

                products.Add(new Product(id, name, price, stock));
            }

            connection.Close();

            return products;
        }
    }
}
