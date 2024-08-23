using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCC.Models
{
    public class OrderDTO
    {
        [Key]
        public int OrderId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public string Customer { get; set; }
        public int Quantity { get; set; }
        public DateTime? OrderDT { get; set; }
    }
}