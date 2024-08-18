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

        #region CREATE
        // GET: Orders
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        public ActionResult Create(Orders order)
        {
            TempData["Type"] = "Create";
            DBmanager dbmanager = new DBmanager();
            try
            {
                if (ModelState.IsValid)
                {
                    dbmanager.CreateOrder(order);
                }
                DateTime date = DateTime.Now;
                ViewBag.Date = date;
                TempData["Result"] = "success";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                TempData["Result"] = "error";
            }

            return RedirectToAction("../Home/Index");
        }
        #endregion

        #region EDIT
        // GET: Orders/Edit?orderId={OrderId}
        public ActionResult Edit(int orderId)
        {
            DBmanager dBmanager = new DBmanager();
            Orders order = dBmanager.GetOrderById(orderId);
            return View(order);
        }

        // POST: Orders/Edit?orderId={OrderId}
        [HttpPost]
        public ActionResult Edit(Orders order)
        {
            TempData["Type"] = "Edit";

            if (ModelState.IsValid)
            {
                DBmanager dbmanager = new DBmanager();
                try
                {
                    dbmanager.UpdateOrder(order);
                    DateTime date = DateTime.Now;
                    ViewBag.Date = date;
                    TempData["Result"] = "success";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    TempData["Result"] = "error";
                }

                return RedirectToAction("../Home/Index");
            }

            return View(order);
        }

        #endregion
    }
}