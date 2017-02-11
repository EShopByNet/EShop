using EShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShop.Models;
using System.Threading.Tasks;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace EShop.Controllers
{
    [Authorize]
    public class CartController : Controller
    {

        private CartService cartService = new CartService();

        // GET: Cart
        public async Task<ActionResult> Index()
        {
            return View(await cartService.FindAll());
        }

        /// <summary>
        /// 添加商品到购物车
        /// </summary>
        /// <param name="goodsId"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Add(string goodsId, int? number)
        {
            if (null == number)
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
            else
            {
                Cart cart = new Cart();
                cart.number = number.Value;
                cart.goodsId = goodsId;
                cart.userId = User.Identity.GetUserId();
                if (!cartService.Add(cart))
                {
                    return Json("error", JsonRequestBehavior.AllowGet);
                }
                return Json("ok", JsonRequestBehavior.AllowGet);
            }
            
        }

    }
}