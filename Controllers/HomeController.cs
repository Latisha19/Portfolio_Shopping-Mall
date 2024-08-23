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
        //[Authorize]
        public ActionResult Index()
        {
            //TestMVCCC_Context db = new TestMVCCC_Context();
            //DBmanager dbmanager = new DBmanager(db);

            ViewBag.Name = User.Identity.Name;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About this side project";

            return View();
        }

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}