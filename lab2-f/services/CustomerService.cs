using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orderingProduct.services
{
    class CustomerService
    {
        public static Customer findCustomerByCompanyName(string companyName, ProductContext context)
        {
            return (from c in context.Customers where c.CompanyName == companyName select c).First();
         
        }
    }
}
