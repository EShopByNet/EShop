using EShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShop.Models;
using System.Threading.Tasks;

namespace EShop.Controllers
{
    [Authorize]
    public class CartController : Controller
    {

        private CartService cartService = new CartService();

        // GET: Cart
        public ActionResult Index()
        {
            return View(cartService.findAll());
        }

    }
}