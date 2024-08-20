using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCC.Models
{
    public class TestMVCCCListViewModel
    {
        public IEnumerable<OrderDTO> Orders { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}