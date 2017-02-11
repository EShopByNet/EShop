using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EShop.Models;
using EShop.Service;
using System.Threading.Tasks;

namespace EShop.Areas.Admin.Controllers
{
    public class CatController : Controller
    {

        private CatService catService = new CatService();

        private FileUploadService fileUpload = new FileUploadService();

        /// <summary>
        /// 进入分类index页面
        /// </summary>
        /// <returns></returns>
        // GET: Admin/Cat
        public async Task<ActionResult> Index()
        {
            return View(await catService.findParent());
        }

        /// <summary>
        /// 获取分类的子分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Admin/Cat/GetChild/2
        public async Task<JsonResult> GetChild(int? id)
        {
            if (id == null)
            {
                return Json("",JsonRequestBehavior.AllowGet);
            }
            List<Cat> cat = await catService.findChild(id.Value);
            return Json(cat,JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取父级分类
        /// </summary>
        /// <returns></returns>
        // GET: Admin/Cat/GetParent
        public async Task<JsonResult> GetParent()
        {
            List<Cat> cat = await catService.findParent();
            return Json(cat, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 进入到一个分类详情页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Admin/Cat/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            // TODO id为空处理待处理
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cat cat = await catService.findOne(id.Value);
            if (cat == null)
            {
                return HttpNotFound();
            }
            else
            {
                 ViewBag.Parentid = id.Value;
                 return View(await catService.findChild(id.Value));
            }
        }


        /// <summary>
        /// 添加一个分类
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        // POST: Admin/Cat/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Exclude = "themePic")] Cat cat)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["themePic"];
                if (null != file)
                {
                    string subFolder = "upload/themes/";
                    string path = fileUpload.Upload(file, Server.MapPath(subFolder));
                    cat.themePic = path;
                }
                if (await catService.create(cat))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index","Error");
                }
            }

            return RedirectToAction("Index", "Error");
        }

        // GET: Admin/Cat/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cat cat = await catService.findOne(id.Value);
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
                await catService.update(cat);
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
            Cat cat = await catService.findOne(id.Value);
            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }

        // POST: Admin/Cat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await catService.delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // TODO 释放资源
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
