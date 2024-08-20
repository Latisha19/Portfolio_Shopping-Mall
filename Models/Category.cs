using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCC.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        // 對應的 Order 集合
        public virtual ICollection<Order> Orders { get; set; }

        public Category()
        {
            CategoryName = string.Empty;
            Description = string.Empty;
        }
        public Category(int _categoryId, string _categoryName, string _description)
        {
            CategoryId = _categoryId;
            CategoryName = _categoryName;
            Description = _description;
        }
    }
}