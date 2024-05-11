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
        public List<Customer> getCustomers()
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

        public bool createCustomer(string name, string address, string phone )

        {
            try
            {
                string cadena = Connection.getCadenaConexion();

                SqlConnection connection = new SqlConnection(cadena);

                connection.Open();

                SqlCommand command = new SqlCommand("USP_InsertCustomer", connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@NAME", name);
                command.Parameters.AddWithValue("@ADDRESS", address);
                command.Parameters.AddWithValue("@PHONE", phone);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return true;
                }
              
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool updateCustomer(int id, string name, string address, string phone)

        {
            try
            {
                string cadena = Connection.getCadenaConexion();

                SqlConnection connection = new SqlConnection(cadena);

                connection.Open();

                SqlCommand command = new SqlCommand("USP_UpdateCustomer", connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@NAME", name);
                command.Parameters.AddWithValue("@ADDRESS", address);
                command.Parameters.AddWithValue("@PHONE", phone);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool deleteCustomer(int id)

        {
            try
            {
                string cadena = Connection.getCadenaConexion();

                SqlConnection connection = new SqlConnection(cadena);

                connection.Open();

                SqlCommand command = new SqlCommand("USP_DeleteCustomer", connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ID", id);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
