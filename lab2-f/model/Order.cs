using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_f
{
    class Order
    {
        private ObservableListSource<OrderDetails> _orderDetails =
                        new ObservableListSource<OrderDetails>();
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CompanyName { get; set; }
        public virtual ObservableListSource<OrderDetails> OrdersDetails { get { return _orderDetails; } }
    

    }
}
