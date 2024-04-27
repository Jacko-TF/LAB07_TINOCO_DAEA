using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class ProductBussiness
    {
        public List<Product> getProductsByName(string name)
        {
            List<Product> products = ProductData.GetProducts();

            List<Product> filteredProducts = products.Where(p => p.name.StartsWith(name)).ToList();

            return filteredProducts;
        }
    }
}
