﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_f
{
    class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer CompanyName { get; set; }
        public List<OrderDetails> OrdersDetails { get; set; }

    }
}
