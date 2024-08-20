using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCC.Models
{
    public class OrderViewModel
    {
        public OrderDTO OrderDto { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}