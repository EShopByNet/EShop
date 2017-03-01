using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EShop.Models;
using EShop.Service;

namespace EShop.Areas.Admin.Controllers
{
    public class GoodsController : Controller
    {

        private GoodsService goodsServer = new GoodsService();

        private FileUploadService fileUpload = new FileUploadService();

        // GET: Admin/Goods
        public async Task<ActionResult> Index()
        {
            return View(await goodsServer.findAll());
        }

        // GET: Admin/Goods/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goods goods = await goodsServer.findOne(id);
            if (goods == null)
            {
                return HttpNotFound();
            }
            return View(goods);
        }

        // GET: Admin/Goods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Goods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Exclude = "image")] Goods goods)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["image"];
                if (null != file)
                {
                    string subFolder = "upload/themes/";
                    string path = fileUpload.Upload(file, Server.MapPath(subFolder));
                    goods.image = path;
                }
                await goodsServer.createGoods(goods);
                return Redirect("Index");
            }

            return View(goods);
        }

        // GET: Admin/Goods/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goods goods = await goodsServer.findOne(id);
            if (goods == null)
            {
                return HttpNotFound();
            }
            return View(goods);
        }

        // POST: Admin/Goods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,name,image,costPrice,price,catId,detailId")] Goods goods)
        {
            if (ModelState.IsValid)
            {
                await goodsServer.update(goods);
                return RedirectToAction("Index");
            }
            return View(goods);
        }

        // GET: Admin/Goods/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goods goods = await goodsServer.findOne(id);
            if (goods == null)
            {
                return HttpNotFound();
            }
            return View(goods);
        }

        // POST: Admin/Goods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            await goodsServer.delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                goodsServer.getContent().Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
