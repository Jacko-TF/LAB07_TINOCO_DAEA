using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CustomerData
    {
        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            string cadena = Connection.getCadenaConexion();

            SqlConnection connection = new SqlConnection(cadena);

            connection.Open();

            SqlCommand command = new SqlCommand("USP_ListCustomers", connection);

            command.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32("customer_id");
                string name = reader.GetString("name");
                string address = reader.GetString("address");
                string phone = reader.GetString("phone");

                customers.Add(new Customer(id, name, address, phone));
            }

            connection.Close();

            return customers;
        }
    }
}
