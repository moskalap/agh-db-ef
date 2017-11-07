using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orderingProduct
{
    class OrderDetails
    {   
        public int OrderId { get; set; }
        [Key]
        public int OrderDetailId { get; set; }
        public Product ProductId { get; set; }
        public int Units { get; set; }
    }
}
