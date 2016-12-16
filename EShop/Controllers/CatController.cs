using EShop.Models;
using EShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EShop.Controllers
{
    [Authorize]
    public class CatController : Controller
    {

        private CatService catService = new CatService();

        // GET: Cat
        public async Task<ActionResult> Index()
        {
            return View(await catService.findAll());
        }

        // GET: Cat/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await catService.findOne(id));
        }

        // GET: Cat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cat/Create
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

        // GET: Cat/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await catService.findOne(id));
        }

        // POST: Cat/Edit/5
        [HttpPost]
        public ActionResult Edit(Cat cat, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View(cat);
            }
        }

        // GET: Cat/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await catService.findOne(id));
        }

        // POST: Cat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View(catService.findOne(id));
            }
        }
    }
}
