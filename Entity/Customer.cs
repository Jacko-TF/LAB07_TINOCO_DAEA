using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Customer
    {
        public int customer_id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }


        public Customer(int id, string name, string addres, string phone)
        {
            this.customer_id = id;
            this.name = name;
            this.address = addres;
            this.phone = phone;
        }
    }
}
