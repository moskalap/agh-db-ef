using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orderingProduct.services
{
    class OrderService
    {
        public static List<Order> findOrderByCustomerId(string companyName, ProductContext context)
        {
            return context.Orders.Where(o => o.CompanyName == companyName).Select( o => o).ToList();
        }
        public static List<OrderDetails> findOrderDetailsByOrderId(int orderId, ProductContext context)
        {
            return (from od in context.OrderDetails where od.OrderId == orderId select od).ToList();
        }

        public static List<OrderBillDto> findOrderBillDtosByOrder(Order order)
        {
            var a = new List<OrderBillDto>();

            foreach (var orderDetail in order.OrdersDetails)
            {
                a.Add(new OrderBillDto { ProductName = orderDetail.ProductId.Name, Unit = orderDetail.Units, UnitPrice = orderDetail.ProductId.UnitPrice });

            }

            return a;
        }
        public static void addOrder(ProductContext context, Customer customter, DateTime orderDate, OrderDetails orderDetails)
        {
            context.Orders.Add(new Order() {CompanyName = customter.CompanyName});
            context.SaveChanges();


        }
        internal static decimal findSumForOrderBill(List<OrderBillDto> orBill)
        {
            decimal sum = 0;

            foreach (var bille in orBill)
            {
                sum += bille.Unit * bille.UnitPrice;
            }
            return sum;
        }
    
        internal static List<string> validOrder(Order order, ProductContext context)
        {
            List<string> errors = new List<string>();

            foreach (OrderDetails od in order.OrdersDetails)
            {
                var left = context.Products.Where(p => p.ProductId == od.ProductId.ProductId).Select(p => p).First();
                if (left.UnitsInStock < od.Units)
                errors.Add(string.Format("{0} zostało sztuk : {1}", left.Name, left.UnitsInStock));

            }
            return errors;
        }
    }
}
