using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_f.services
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




        internal static decimal findSumForOrderBill(List<OrderBillDto> orBill)
        {
            decimal sum = 0;

            foreach (var bille in orBill)
            {
                sum += bille.Unit * bille.UnitPrice;
            }
            return sum;
        }
    }
}
