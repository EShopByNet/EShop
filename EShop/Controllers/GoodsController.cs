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

namespace EShop.Controllers
{
    public class GoodsController : Controller
    {
        private EShopDbContext db = new EShopDbContext();

        private GoodsService goodsService = new GoodsService();

        /// <summary>
        /// GET: Goods
        /// 获取商品列表
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {           
            return View(await db.Goods.ToListAsync());
        }

        /// <summary>
        /// GET: Goods/Details/5
        /// 获取商品详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goods goods = await db.Goods.FindAsync(id);
            if (goods == null)
            {
                return HttpNotFound();
            }
            return View(goods);
        }

        /// <summary>
        /// GET: Goods/Create
        /// 进入添加商品页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// POST: Goods/Create
        /// 保存一个添加的商品
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id")] Goods goods)
        {
            if (ModelState.IsValid)
            {
                bool result =await goodsService.createGoods(goods);
                if (result == true)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(goods);
        }

        /// <summary>
        /// GET: Goods/Edit/5
        /// 进入一个商品的编辑页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goods goods = await db.Goods.FindAsync(id);
            if (goods == null)
            {
                return HttpNotFound();
            }
            return View(goods);
        }

        /// <summary>
        /// POST: Goods/Edit/5
        /// 保存一个商品的编辑信息
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id")] Goods goods)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goods).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(goods);
        }

        /// <summary>
        /// GET: Goods/Delete/5
        /// 进入一个商品的删除页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goods goods = await db.Goods.FindAsync(id);
            if (goods == null)
            {
                return HttpNotFound();
            }
            return View(goods);
        }

        /// <summary>
        /// POST: Goods/Delete/5
        /// 删除一个商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Goods goods = await db.Goods.FindAsync(id);
            db.Goods.Remove(goods);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 非托管资源释放
        /// </summary>
        /// <param name="disposing"></param>
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
