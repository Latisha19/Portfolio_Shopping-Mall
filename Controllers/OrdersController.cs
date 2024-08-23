using MVCCC.DAL;
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
        #region CREATE

        // GET: Orders
        public ActionResult Create()
        {
            TestMVCCC_Context db = new TestMVCCC_Context();
            List<SelectListItem> categories = db.Categories
                                                .Select(c => new SelectListItem
                                                {
                                                    Text = c.CategoryName,
                                                    Value = c.CategoryId.ToString()
                                                })
                                                .ToList();

            OrderViewModel viewModel = new OrderViewModel
            {
                Categories = categories
            };
            return View(viewModel);
        }

        // POST: Orders/Create
        [HttpPost]
        public ActionResult Create(OrderViewModel orderViewModel)
        {
            TempData["Type"] = "Create";
            TestMVCCC_Context db = new TestMVCCC_Context();
            DBmanager dbmanager = new DBmanager(db);
            try
            {
                if (ModelState.IsValid)
                {
                    dbmanager.CreateOrder(orderViewModel.OrderDto);
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
        [HttpGet]
        public ActionResult Edit(int orderId)
        {
            TestMVCCC_Context db = new TestMVCCC_Context();
            DBmanager dBmanager = new DBmanager(db);
            OrderDTO orderDTO = dBmanager.GetOrderById(orderId);

            List<SelectListItem> categories = db.Categories
                                                .Select(c => new SelectListItem
                                                {
                                                    Text = c.CategoryName,
                                                    Value = c.CategoryId.ToString()
                                                })
                                                .ToList();

            // 使用 ViewModel
            OrderViewModel viewModel = new OrderViewModel
            {
                OrderDto = orderDTO,
                Categories = categories
            };

            return View(viewModel);
        }

        // POST: Orders/Edit?orderId={OrderId}
        [HttpPost]
        public ActionResult Edit(OrderViewModel orderViewModel)
        {
            TempData["Type"] = "Edit";

            if (ModelState.IsValid)
            {
                TestMVCCC_Context db = new TestMVCCC_Context();
                DBmanager dbmanager = new DBmanager(db);
                try
                {
                    dbmanager.UpdateOrder(orderViewModel.OrderDto);
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

            return View(orderViewModel);
        }

        #endregion

        [HttpPost]
        public ActionResult Delete(int orderId)
        {
            TempData["Type"] = "Delete";

            if (ModelState.IsValid)
            {
                TestMVCCC_Context db = new TestMVCCC_Context();
                DBmanager dbmanager = new DBmanager(db);
                try
                {
                    dbmanager.DeleteOrder(orderId);
                    DateTime date = DateTime.Now;
                    ViewBag.Date = date;
                    TempData["Result"] = "success";
                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    TempData["Result"] = "error";
                    return Json(new { success = false });
                }
            }
            return View();
        }
    }
}