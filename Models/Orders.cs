using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MVCCC.Models
{
    public class Orders
    {
        public int OrderId { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public string Customer { get; set; }
        public Orders()
        {
            OrderId = 0;
            Category = string.Empty;
            Name = string.Empty;
            Price = null;
            Customer = string.Empty;
        }
        public Orders(int _orderId, string _category, string _name, int? _price, string _customer)
        {
            OrderId = _orderId;
            Category = _category;
            Name = _name;
            Price = _price;
            Customer = _customer;
        }
    }
}