using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_f
{
    class OrderDetails
    {   
        public int OrderId { get; set; }
        [Key]
        public int OrderDetailId { get; set; }
        public Product Product { get; set; }
        public int Units { get; set; }
    }
}
