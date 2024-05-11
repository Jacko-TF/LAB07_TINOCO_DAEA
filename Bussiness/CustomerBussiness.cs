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
            List<Customer> customers = customerData.getCustomers();

            List<Customer> filteredCustomers = customers.Where(p => p.name.StartsWith(name)).ToList();

            return filteredCustomers;
        }

        public bool createCustomer(string name, string address, string phone)
        {

            bool created = customerData.createCustomer(name, address, phone);

            return created;
        }

        public bool updateCustomer(int id, string name, string address, string phone)
        {

            bool updated = customerData.updateCustomer(id, name, address, phone);

            return updated;

        }
        public bool deleteCustomer(int id)
        {

            bool deleted = customerData.deleteCustomer(id);

            return deleted;
        }
    }
}
