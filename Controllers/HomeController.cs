using MVCCC.DAL;
using MVCCC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DateTime date = DateTime.Now;

            TestMVCCC_Context db = new TestMVCCC_Context();
            DBmanager dbmanager = new DBmanager(db);
            List<OrderDTO> orders = dbmanager.GetOrders();
            var categories = db.Categories
                                .Select(c => new { c.CategoryId, c.CategoryName })
                                .ToList();

            // 如果使用匿名類型，請定義相應的類型
            var categoryList = categories.Select(c => new Category
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName
            }).ToList();

            // 創建 ViewModel
            var viewModel = new TestMVCCCListViewModel
            {
                Orders = orders,
                Categories = categoryList
            };

            ViewBag.Date = date;
            ViewBag.Orders = orders;

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "About Me";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}