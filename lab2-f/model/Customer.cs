using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_f
{
    class Customer
    {   
        [Key]
        public string CompanyName { get; set; }
        public string Descritpion { get; set; }
    }
}
