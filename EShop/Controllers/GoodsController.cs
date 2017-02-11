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
using System.IO;

namespace EShop.Controllers
{
    public class GoodsController : Controller
    {
        private GoodsService goodsService = new GoodsService();

        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <returns></returns>
        //  GET: Goods
        public async Task<ActionResult> Index()
        {           
            return View(await goodsService.list());
        }

        /// <summary>
        /// 获取商品详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //  GET: Goods/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoodsData doods = goodsService.findOneDetail(id);
            if (doods == null)
            {
                return HttpNotFound();
            }
            return View(doods);
        }

        /// <summary>
        /// GET: Goods/Create
        /// 进入添加商品页面
        /// </summary>
        /// <returns></returns>
        [Authorize]
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
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Goods goods)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["image"];
                if (file != null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    string filePath = "/Images/goods/" + fileName;
                    var path = Server.MapPath(filePath);
                    file.SaveAs(path);
                    goods.image = filePath;
                }
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
        [Authorize]
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goods goods = await goodsService.findOne(id);
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
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id")] Goods goods)
        {
            if (ModelState.IsValid)
            {
                await goodsService.update(goods);
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
        [Authorize]
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goods goods = await goodsService.findOne(id);
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
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            await goodsService.delete(id);
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
                goodsService.getContent().Dispose();
            }
            base.Dispose(disposing);
        }

        [Authorize]
        public ActionResult Classify()
        {

            return View();
        }
    }
}
