using EShop.Models;
using EShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace EShop.Controllers
{
    public class HomeController : Controller
    {
        private EShopDbContext db = new EShopDbContext();

        private GoodsService goodsService = new GoodsService();

        private CatService catService = new CatService();

        //
        public async Task<ActionResult> Index()
        {
            List<CatData> catdata = await catService.findAll();
            ViewBag.Cat = catdata;
            return View(goodsService.findCatShopBySize(4));
        }

        public async Task<ActionResult> About(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goods goods = await db.Goods.FindAsync(id);
            GoodsData goodsData = new GoodsData();
            goodsData.albums = db.Album.Where(u=>u.goodsId.Equals(id)).ToList();
            goodsData.goods = goods;
            if (goods == null)
            {
                return HttpNotFound();
            }
            return View(goodsData);
        }

        public ActionResult Orders()
        {

            return View();
        }

        public ActionResult ShoppingCart()
        {

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}