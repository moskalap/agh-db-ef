

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_f.services
{
    class ProductService
    {
        ProductContext context;

        public Product findProductById(int productId)
        {
            return context.Products.Where(p => p.ProductId == productId).First();
        }

        
        public List<Product> findProductsByCategoryId(int categoryId)
        {
            return (from p in context.Products select p).ToList();
        }


    }
}
