using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class CustomerBussiness
    {
        public CustomerData customerData = new CustomerData();

        public List<Customer> getCustomersByName(string name)
        {
            List<Customer> customers = customerData.GetCustomers();

            List<Customer> filteredCustomers = customers.Where(p => p.name.StartsWith(name)).ToList();

            return filteredCustomers;
        }
    }
}
