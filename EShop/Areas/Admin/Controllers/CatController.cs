using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EShop.Models;
using System.Threading.Tasks;
using EShop.Service;

namespace EShop.Areas.Admin.Controllers
{
    public class CatController : Controller
    {
        private EShopDbContext db = new EShopDbContext();

        private CatService catService = new CatService();

        /// <summary>
        /// 进入分类index页面
        /// </summary>
        /// <returns></returns>
        // GET: Admin/Cat
        public async Task<ActionResult> Index()
        {
            return View(await catService.findAll());
        }

        /// <summary>
        /// 进入到一个分类详情页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Admin/Cat/Details/5
        public async Task<ActionResult> Details(int id)
        {
            // TODO id为空处理待处理
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cat cat = await catService.findOne(id);
            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }

        // GET: Admin/Cat/Create
        public ActionResult Create()
        {
            return View();
        }


        /// <summary>
        /// 添加一个分类
        /// Bind 设置绑定的字段，以防止过度发布
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        // POST: Admin/Cat/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<bool> Create([Bind(Include = "Id,ParentId,Name,IsShow,IsDelete")] Cat cat)
        {
            if (ModelState.IsValid)
            {
                if(await catService.create(cat))
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }

            return false;
        }

        // GET: Admin/Cat/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cat cat = await db.Cat.FindAsync(id);
            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }

        // POST: Admin/Cat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ParentId,Name,IsShow,IsDelete")] Cat cat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cat).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cat);
        }

        // GET: Admin/Cat/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cat cat = await db.Cat.FindAsync(id);
            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }

        // POST: Admin/Cat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cat cat = db.Cat.Find(id);
            db.Cat.Remove(cat);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
