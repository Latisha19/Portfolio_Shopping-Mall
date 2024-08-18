using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCC.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public Categories()
        {
            CategoryName = string.Empty;
            Description = string.Empty;
        }
        public Categories(int _categoryId, string _categoryName, string _description)
        {
            CategoryId = _categoryId;
            CategoryName = _categoryName;
            Description = _description;
        }
    }
}