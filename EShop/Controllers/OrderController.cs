using EShop.Models;
using EShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace EShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {

        private OrderService orderService = new OrderService();

        // GET: Order
        public ActionResult Index()
        { 
            return View(orderService.findAll(User.Identity.GetUserId()));
        }

        // GET: Order/Details/5
        public async Task<ActionResult> Details(string id)
        {
            return View(await orderService.findOne(id));
        }

        // GET: Order/Create
        public ActionResult Create(List<Cart> cart)
        {
            orderService.create(cart);
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            return View(await orderService.findOne(id));
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
        public async Task<ActionResult> Delete(string id)
        {
            return View(await orderService.findOne(id));
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
