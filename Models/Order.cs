using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCC.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public string Customer { get; set; }
        public int Quantity { get; set; }

        // 對應的 Category 對象
        public virtual Category Category { get; set; }

        public Order()
        {
            CategoryId = -1;
            Name = string.Empty;
            Price = null;
            Customer = string.Empty;
            Quantity = 1;
        }
        public Order(int _orderId, int _categoryId, string _name, int? _price, string _customer, int _quantity)
        {
            OrderId = _orderId;
            CategoryId = _categoryId;
            Name = _name;
            Price = _price;
            Customer = _customer;
            Quantity = _quantity;
        }

        //public string Type { get; set; }

        //public IEnumerable<SelectListItem> TypeList
        //{
        //    get
        //    {
        //        return new List<SelectListItem>
        //        {
        //            new SelectListItem { Text = "Football", Value = "Football"},
        //            new SelectListItem { Text = "Rugby", Value = "Rugby"},
        //            new SelectListItem { Text = "Horse Racing", Value = "Horse Racing"}
        //        };
        //    }
        //}
    }
}