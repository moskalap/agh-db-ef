using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orderingProduct
{
    class Customer
    {
        private readonly ObservableListSource<Order> _orders =
                        new ObservableListSource<Order>();
        [Key]
        public string CompanyName { get; set; }
        public string Descritpion { get; set; }
        public string EMail { get; set; }
        public string Adress { get; set; }
        public virtual ObservableListSource<Order> Orders { get { return _orders; } }
    }
}