using EShop.Models;
using EShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {

        private OrderService orderService = new OrderService();

        // GET: Order
        public ActionResult Index()
        {
            return View(orderService.findAll());
        }

        // GET: Order/Details/5
        public ActionResult Details(string id)
        {
            return View(orderService.findOne(id));
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(string id)
        {
            return View(orderService.findOne(id));
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(Order order, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View(order);
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(string id)
        {
            return View(orderService.findOne(id));
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View(orderService.findOne(id));
            }
        }
    }
}
