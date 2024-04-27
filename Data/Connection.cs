using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class Connection
    {
        public static string getCadenaConexion()
        {
            string connectionString = "Data Source=LAB1504-15\\SQLEXPRESS;Initial Catalog=FacturaDB;User Id=jacko;Password=admin";
            return connectionString;
        }
    }

}
