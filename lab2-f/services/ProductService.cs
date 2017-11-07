

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orderingProduct.services
{
    class ProductService
    {
        ProductContext context;

        public static Product findProductById(ProductContext context, int productId)
        {
            return context.Products.Where(p => p.ProductId == productId).First();
        }

        
        public static List<Product> findProductsByCategoryId(ProductContext context, int categoryId)
        {
            return (from p in context.Products select p).ToList();
        }

        public static Object getCategoriesWithProducts(ProductContext context)
        {
            return context.Categories.Join(context.Products,
                                   c => c.CategoryId,
                                   p => p.CategoryId,
                                   (c, p) => new { Name = c.Name, Products = p }).Select(x => x).ToList();
        }

        public static Object getCategoriesWithProductsQuerySyntax(ProductContext context)
        {
            return (from c in context.Categories
                    join p in context.Products
                    on c.CategoryId equals p.CategoryId
                    select c).ToList();
        }

        public static int supplyNewProducts(ProductContext context, int productId, int units)
        {
           var product = context.Products.
                            Where(p => p.ProductId == productId).First();

           product.UnitsInStock += units;
           context.SaveChanges();
           return product.UnitsInStock;
            
        }

    }
}
