using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MVCCC.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public string Customer { get; set; }
        public int Quantity { get; set; }
        public Orders()
        {
            CategoryId = string.Empty;
            Name = string.Empty;
            Price = null;
            Customer = string.Empty;
            Quantity = 1;
        }
        public Orders(int _orderId, string _categoryId, string _name, int? _price, string _customer, int _quantity)
        {
            OrderId = _orderId;
            CategoryId = _categoryId;
            Name = _name;
            Price = _price;
            Customer = _customer;
            Quantity = _quantity;
        }
    }
}