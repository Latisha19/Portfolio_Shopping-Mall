using MVCCC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCC.Controllers
{
    public class OrdersController : Controller
    {
        private readonly string Connstr = ConfigurationManager.ConnectionStrings["MSSQL_DBconnect"].ConnectionString;

        // GET: Orders
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        public ActionResult Create(Orders order)
        {
            DBmanager dbmanager = new DBmanager();
            try
            {
                if (ModelState.IsValid)
                {
                    dbmanager.CreateOrders(order);
                }
                DateTime date = DateTime.Now;
                ViewBag.Date = date;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return RedirectToAction("../Home/Index");
        }
    }
}